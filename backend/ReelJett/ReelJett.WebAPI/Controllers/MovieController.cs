using RestSharp;
using System.Text.Json;
using ReelJett.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using ReelJett.Domain.ViewModels;
using ReelJett.Application.Services;
using Microsoft.IdentityModel.Tokens;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;

namespace ReelJett.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase {

    // Fields

    private readonly IScrapingService _scrapingService;
    private readonly IReadMovieRepository _readMovieRepository;
    private readonly IWriteMovieRepository _writeMovieRepository;
    private readonly IReadProffesionalMovieRepository _readProffesionalMovieRepository;
    private readonly IWriteProffesionalMovieRepository _writeProffesionalMovieRepository;

    // Constructor

    public MovieController(IReadMovieRepository readMovieRepository, IWriteMovieRepository writeMovieRepository,
                    IReadProffesionalMovieRepository readProffesionalMovieRepository, IWriteProffesionalMovieRepository writeProffesionalMovieRepository,
                    IScrapingService scrapingService) { 

        _scrapingService = scrapingService;
        _readMovieRepository = readMovieRepository;
        _writeMovieRepository = writeMovieRepository;
        _readProffesionalMovieRepository = readProffesionalMovieRepository;
        _writeProffesionalMovieRepository = writeProffesionalMovieRepository;
    }

    // Methods

    [HttpGet("GetNewReleaseMovies")]
    public async Task<IActionResult> GetNewReleaseMovies([FromQuery] int page, int moviesPerPage, string language) {

        var newreleasemovies = new List<MovieDTO>();
        for (int i = 1; i <= 3; i++) {
            var options = new RestClientOptions($"https://api.themoviedb.org/3/movie/now_playing?language={language}&page={i}");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwN2I3OWYxNmU2NWFmMGY1YTBjNGY4ZGFkZDdkMDhjNCIsInN1YiI6IjY0YjA0MzFjMjBlY2FmMDBjNmY2MWQ1ZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.VErhjbegJJ2tyZVP-GiDRN_gTcH_MYVhQ1wThi0Ytb0");
            var response = await client.GetAsync(request);
            var movies = JsonSerializer.Deserialize<MovieData>(response.Content!);

            newreleasemovies.AddRange(movies!.results);
        }

        var filteredMovies = new List<MovieDTO>();
        for (int i = (page - 1) * moviesPerPage; i < page * moviesPerPage; i++) {
            if (i == newreleasemovies.Count) break;
            filteredMovies.Add(newreleasemovies[i]);
        }

        var movieVM = new MovieVM() {
            Movies = filteredMovies,
            TotalPages = (newreleasemovies.Count % moviesPerPage == 0) ?
                            (newreleasemovies.Count / moviesPerPage) 
                         :
                            (newreleasemovies.Count / moviesPerPage) + 1,
        };

        return Ok(movieVM);
    }

    [HttpGet("GetUpcomingMovies")]
    public async Task<IActionResult> GetUpcomingMovies([FromQuery] string language) {

        var options = new RestClientOptions($"https://api.themoviedb.org/3/movie/upcoming?language={language}&page=1");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwN2I3OWYxNmU2NWFmMGY1YTBjNGY4ZGFkZDdkMDhjNCIsInN1YiI6IjY0YjA0MzFjMjBlY2FmMDBjNmY2MWQ1ZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.VErhjbegJJ2tyZVP-GiDRN_gTcH_MYVhQ1wThi0Ytb0");
        var response = await client.GetAsync(request);
        var moviedata = JsonSerializer.Deserialize<MovieData>(response.Content!);
        var movies = moviedata?.results.ToList();

        var filteredMovies = new List<MovieDTO>();
        for (int i = 0; i < 4; i++)
            filteredMovies.Add(movies[i]);

        var movieVM = new MovieVM() {
            Movies = filteredMovies,
            TotalPages = 1
        };

        return Ok(movieVM);
    }

    [HttpGet("GetInterestedMovies")]
    public async Task<IActionResult> GetInterestedMovies([FromQuery] int movieid, string language) {

        var options = new RestClientOptions($"https://api.themoviedb.org/3/movie/{movieid}/recommendations?language={language}&page=1");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwN2I3OWYxNmU2NWFmMGY1YTBjNGY4ZGFkZDdkMDhjNCIsInN1YiI6IjY0YjA0MzFjMjBlY2FmMDBjNmY2MWQ1ZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.VErhjbegJJ2tyZVP-GiDRN_gTcH_MYVhQ1wThi0Ytb0");
        var response = await client.GetAsync(request);
        var moviedata = JsonSerializer.Deserialize<MovieData>(response.Content!);
        var movies = moviedata?.results.ToList();

        var filteredMovies = new List<MovieDTO>();
        if (movies!.Count >= 4) 
            for (int i = 0; i < 4; i++)
            filteredMovies.Add(movies![i]);

        var movieVM = new MovieVM() {
            Movies = filteredMovies,
            TotalPages = 1
        };

        return Ok(movieVM);
    }

    [HttpGet("GetMovieDetails")]
    public async Task<IActionResult> GetMovieDetails([FromQuery] int movieid, string title,string language) {

        var movie = await _readMovieRepository.GetByIdAsync(movieid.ToString());

        if (movie == null) {

            var newMovie = new Movie() {
                Id = movieid.ToString(),
                Title = title
            };
            await _writeMovieRepository.AddAsync(newMovie);

            var newProffesionalMovie = new ProffesionalMovie() {
                MovieId = movieid.ToString()
            };
            await _writeProffesionalMovieRepository.AddAsync(newProffesionalMovie);

            movie = newMovie;
        }
        else {
            var movieDetailsVM = new MovieDetailsVM() {
                Title = movie.Title,
                LikeCount = movie.LikeCount,
                DislikeCount = movie.DislikeCount,
                ViewCount = movie.ViewCount,
                Runtime = movie.Runtime,
                Categories = movie.Categories,
            };
            return Ok(movieDetailsVM);
        }
 
        var options = new RestClientOptions($"https://api.themoviedb.org/3/movie/{movieid}?language={language}");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwN2I3OWYxNmU2NWFmMGY1YTBjNGY4ZGFkZDdkMDhjNCIsIm5iZiI6MTcyMjQ2NjU2OC41MDQ1NjksInN1YiI6IjY0YjA0MzFjMjBlY2FmMDBjNmY2MWQ1ZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.84Lcw6zUKyCbEv5YfDetGmzWCWPQWBzr-sZ_xdiRXxY");
        var response = await client.GetAsync(request);

        if (response.IsSuccessful) {
            var movieDetailsData = JsonSerializer.Deserialize<MovieDetailsData>(response.Content!);
            var categories = string.Join(", ", movieDetailsData!.genres.Select(p => p.name).ToList());

            movie.Categories = categories;
            movie.Runtime = movieDetailsData.runtime;
            movie.Poster = movieDetailsData.poster_path;
            movie.Rating = movieDetailsData.vote_average;
            await _writeMovieRepository.UpdateAsync(movie);

            var movieDetailsVM = new MovieDetailsVM() {
                Title = movie.Title,
                LikeCount = movie.LikeCount,
                DislikeCount = movie.DislikeCount,
                ViewCount = movie.ViewCount,
                Runtime = movieDetailsData.runtime,
                Categories = categories,
            };
            return Ok(movieDetailsVM);
        }
        return BadRequest(response.StatusDescription);
    }

    [HttpGet("GetSearchedMovie")]
    public async Task<IActionResult> GetSearchedMovie([FromQuery] string query, int page, int moviesPerPage,string language) {

        var options = new RestClientOptions($"https://api.themoviedb.org/3/search/movie?query={query}&include_adult=false&language={language}&page={page}");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwN2I3OWYxNmU2NWFmMGY1YTBjNGY4ZGFkZDdkMDhjNCIsIm5iZiI6MTcyMjQ2NjU2OC41MDQ1NjksInN1YiI6IjY0YjA0MzFjMjBlY2FmMDBjNmY2MWQ1ZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.84Lcw6zUKyCbEv5YfDetGmzWCWPQWBzr-sZ_xdiRXxY");
        var response = await client.GetAsync(request);
        var moviedata = JsonSerializer.Deserialize<MovieData>(response.Content!);
        var movies = moviedata?.results.ToList();

        var filteredMovies = new List<MovieDTO>();
        for(int i = (page - 1) * moviesPerPage; i < page * moviesPerPage; i++) {
            if (i == movies.Count) break;
            filteredMovies.Add(movies[i]);
        }

        var movieVM = new MovieVM() {
            Movies = filteredMovies,
            TotalPages = (movies.Count % moviesPerPage == 0) ?
                            (movies.Count / moviesPerPage)
                         :
                            (movies.Count / moviesPerPage) + 1,
        };
        return Ok(movieVM);
    }

    [HttpGet("GetSearchedPerson")]
    public async Task<IActionResult> GetSearchedPerson([FromQuery] string query, int page, int personPerPage, string language)
    {

        var options = new RestClientOptions($"https://api.themoviedb.org/3/search/person?query={query}&include_adult=false&language={language}&page={page}");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwN2I3OWYxNmU2NWFmMGY1YTBjNGY4ZGFkZDdkMDhjNCIsIm5iZiI6MTcyMjQ2NjU2OC41MDQ1NjksInN1YiI6IjY0YjA0MzFjMjBlY2FmMDBjNmY2MWQ1ZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.84Lcw6zUKyCbEv5YfDetGmzWCWPQWBzr-sZ_xdiRXxY");
        var response = await client.GetAsync(request);
        var persondata = JsonSerializer.Deserialize<PersonData>(response.Content!);
        var people = persondata?.results.ToList();

        var filteredPeople = new List<PersonDTO>();
        for (int i = (page - 1) * personPerPage; i < page * personPerPage; i++)
        {
            if (i == people.Count) break;
            filteredPeople.Add(people[i]);
        }

        var personVM = new PersonVM()
        {
            People = filteredPeople,
            TotalPages = (people.Count % personPerPage == 0) ?
                            (people.Count / personPerPage)
                         :
                            (people.Count / personPerPage) + 1,
        };
        return Ok(personVM);
    }



    [HttpGet("GetMovieEmbedLink")]
    public async Task<IActionResult> GetMovieEmbedLink([FromQuery] int movieid, string title, string year) {

        var newVideoOptions = new VideoOptionsVM();
        var movie = await _readProffesionalMovieRepository.GetByMovieId(movieid.ToString());

        if (movie == null) {

            var newMovie = new Movie() {
                Id = movieid.ToString(),
                Title = title
            };
            await _writeMovieRepository.AddAsync(newMovie);

            var newProffesionalMovie = new ProffesionalMovie() {
                MovieId = movieid.ToString()
            };
            await _writeProffesionalMovieRepository.AddAsync(newProffesionalMovie);

            movie = newProffesionalMovie;
        }
        else if (!movie.MultipleUrl.IsNullOrEmpty() || !movie.TRDublaj.IsNullOrEmpty() || !movie.TRAltyazi.IsNullOrEmpty()) {
            newVideoOptions = new() {
                Dublaj = movie.TRDublaj,
                Altyazi = movie.TRAltyazi,
                Multiple = $"https://multiembed.mov/?video_id={movieid}&tmdb=1"
            };
            return Ok(newVideoOptions);
        }

        var result = _scrapingService.StartScrape(title, year);
        if (result != null) {
            newVideoOptions = new() {
                Dublaj = result[0],
                Altyazi = result[1],
                Multiple = $"https://multiembed.mov/?video_id={movieid}&tmdb=1"
            };
            movie.TRDublaj = result[0];
            movie.TRAltyazi = result[1];
        }
        else {
            newVideoOptions = new() {
                Dublaj = "Not Found",
                Altyazi = "Not Found",
                Multiple = $"https://multiembed.mov/?video_id={movieid}&tmdb=1"
            };
            movie.TRDublaj = "Not Found";
            movie.TRAltyazi = "Not Found";
        }
        movie.MultipleUrl = $"https://multiembed.mov/?video_id={movieid}&tmdb=1";
        await _writeProffesionalMovieRepository.UpdateAsync(movie);
        return Ok(newVideoOptions);
    }

    [HttpGet("GetTrailer")]
    public async Task<IActionResult> GetTrailer(string movieid, string language) {
        var options = new RestClientOptions($"https://api.themoviedb.org/3/movie/{movieid}/videos?language={language}");
        var client = new RestClient(options);
        var request = new RestRequest("");
        request.AddHeader("accept", "application/json");
        request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIwN2I3OWYxNmU2NWFmMGY1YTBjNGY4ZGFkZDdkMDhjNCIsIm5iZiI6MTcyNTc4ODgwNy41NDY3MzgsInN1YiI6IjY0YjA0MzFjMjBlY2FmMDBjNmY2MWQ1ZSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.tBkdbQk8s3ia-nu9x5PV0vLPHWEx6SxgPsoBzWIWBG4");
        var response = await client.GetAsync(request);

        string trailer = "";
        int size = 0;
        var videoDTO = JsonSerializer.Deserialize<VideoDTO>(response.Content!);
        videoDTO!.results.ToList().ForEach(result => { 
            if (result.type == "Trailer" && result.site == "YouTube") {
                if (trailer != "" && result.size > size) {
                    trailer = "https://www.youtube.com/embed/" + result.key;
                    size = result.size;
                }
                else if (trailer == "") {
                    trailer = "https://www.youtube.com/embed/" + result.key;
                    size = result.size;
                }
            }
        });

        return Ok(trailer);
    }
}