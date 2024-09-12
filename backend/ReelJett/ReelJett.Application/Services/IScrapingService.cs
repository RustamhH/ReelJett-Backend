namespace ReelJett.Application.Services;

public interface IScrapingService {

    // Methods

    void SearchAlgorithm(string title);
    string? FindVideoLink(string searchlink);
    void FindEmbedVideoLink(string? VideoPageLink);
    List<string>? StartScrape(string title, string year);
}