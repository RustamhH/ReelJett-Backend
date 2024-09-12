using HtmlAgilityPack;
using ReelJett.Application.Services;

namespace ReelJett.Infrastructure.Services;

public class ScrapingService : IScrapingService {

    // Fields

    private string _year;
    public string Dublaj;
    public string Altyazi;
    private string _search;
    public string VideoUrl;

    // Methods

    public void SearchAlgorithm(string title) {
        _search = title.ToLower();
        _search = _search.Replace(" ", "+");
        _search = _search.Replace("ı", "i");
    }

    public void FindEmbedVideoLink(string? VideoPageLink) {

        var httpClient = new HttpClient();
        var htmlDocument = new HtmlDocument();
        var html = httpClient.GetStringAsync(VideoPageLink).Result;
        htmlDocument.LoadHtml(html);

        var linkContainer = htmlDocument.DocumentNode.SelectSingleNode("//iframe[@src]");

        HtmlAttribute scrapingLink = linkContainer.Attributes["src"];

        if (scrapingLink.Value.Substring(0, 5) == "https") VideoUrl = scrapingLink.Value;
        else VideoUrl = "https:" + scrapingLink.Value;

        if (VideoUrl.Contains("youtube.com"))
            throw new Exception("Trailer Link");
    }

    public string? FindVideoLink(string searchlink) {

        string url = searchlink + _search;
        var httpClient = new HttpClient();
        var html = httpClient.GetStringAsync(url).Result;
        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(html);

        HtmlAttribute? scr = null;
        HtmlNodeCollection movieDetailNodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='movie-details existing-details']");

        if (movieDetailNodes == null) return null;
        foreach (var node in movieDetailNodes) {
            try {
                if (node.InnerText.Contains(_year)) {
                    var doc = new HtmlDocument();
                    doc.LoadHtml(node.InnerHtml);

                    var nameDiv = doc.DocumentNode.SelectSingleNode("//div[@class='name']");
                    var anchorElement = nameDiv.SelectSingleNode("a");
                    scr = anchorElement.Attributes["href"];
                    break;
                }
            }
            catch { }
        }
        return scr!.Value;
    }

    // Scraping

    public List<string>? StartScrape(string title, string year) {
        SearchAlgorithm(title);
        _year = year;
        if (ScrapeFullHdIzle()) return new List<string>() { Dublaj, Altyazi};
        else if(ScrapeFullFilmIzleNet()) return new List<string>() { Dublaj, Altyazi };
        else if (ScrapeFilmIzlesenePro()) return new List<string>() { Dublaj, Altyazi };
        else if (ScrapeDiziBox()) return new List<string>() { Dublaj, Altyazi };
        else return null;
    }

    // DiziBox

    public bool ScrapeDiziBox() {

        try {
            string? VideoPageLink = FindVideoLink("https://www.dizifilmbox.pw/?s=");
            FindEmbedVideoLink(VideoPageLink + "/2/");
            Dublaj = VideoUrl;
            FindEmbedVideoLink(VideoPageLink + "/4/");
            Altyazi = VideoUrl;
            if (Dublaj.Contains("vidload.lol")) Dublaj = "Not Found";
            if (Altyazi.Contains("vidload.lol")) Altyazi = "Not Found";
            if (Dublaj == "Not Found" && Altyazi == "Not Found") return false;
            else return true;
        }
        catch {
            return false;
        }
    }

    // FullFilmIzle.net

    public bool ScrapeFullFilmIzleNet() {

        try {
            string? VideoPageLink = FindVideoLink("https://fullfilmizle.net/?s=");
            FindEmbedVideoLink(VideoPageLink + "/1/");
            Dublaj = VideoUrl;
            FindEmbedVideoLink(VideoPageLink + "/2/");
            Altyazi = VideoUrl;
            if (Dublaj.Contains("vidload.lol")) Dublaj = "Not Found";
            if (Altyazi.Contains("vidload.lol")) Altyazi = "Not Found";
            if (Dublaj == "Not Found" && Altyazi == "Not Found") return false;
            else return true;
        }
        catch {
            return false;
        }
    }

    // FullHdIzle.me

    public bool ScrapeFullHdIzle() {

        try {
            string? VideoPageLink = FindVideoLink("https://www.fullhdizle.one/?s=");
            FindEmbedVideoLink(VideoPageLink + "/1/");
            Dublaj = VideoUrl;
            FindEmbedVideoLink(VideoPageLink + "/2/");
            Altyazi = VideoUrl;
            if (Dublaj.Contains("vidload.lol")) Dublaj = "Not Found";
            if (Altyazi.Contains("vidload.lol")) Altyazi = "Not Found";
            if (Dublaj == "Not Found" && Altyazi == "Not Found") return false;
            else return true;
        }
        catch {
            return false;
        }
    }

    public bool ScrapeFilmIzlesenePro() {

        try {
            string? VideoPageLink = FindVideoLink("https://www.filmizlesene.pro/?s=");
            FindEmbedVideoLink(VideoPageLink + "/1/");
            Dublaj = VideoUrl;
            FindEmbedVideoLink(VideoPageLink + "/2/");
            Altyazi = VideoUrl;
            if (Dublaj.Contains("vidload.lol")) Dublaj = "Not Found";
            if (Altyazi.Contains("vidload.lol")) Altyazi = "Not Found";
            if (Dublaj == "Not Found" && Altyazi == "Not Found") return false;
            else return true;
        }
        catch {
            return false;
        }
    }
}