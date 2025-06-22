using ReelJett.Domain.DTO;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ReelJett.Domain.ViewModels;
using ReelJett.Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace ReelJett.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonalMovieController : ControllerBase {

    // Fields

    private readonly IPersonalMovieService _personalMovieService;

    // Constructor

    public PersonalMovieController(IPersonalMovieService personalMovieService) {

        _personalMovieService = personalMovieService;
    }

    // Methods

    [Authorize]
    [HttpPost("AddPersonalMovie")]
    public async Task<IActionResult> AddPersonalMovie([FromBody] AddPersonalMovieDTO addPersonalMovieDTO) {
        var errormessage = await _personalMovieService.AddPersonalMovieAsync(addPersonalMovieDTO, User.FindFirst(ClaimTypes.Name)?.Value!);
        if (errormessage == "") return Ok("Movie uploaded successfully");
        else return BadRequest(errormessage);

    }

    [HttpGet("GetPersonalMovies")]
    public async Task<IActionResult> GetPersonalMovies([FromQuery] int page, int moviesPerPage) {

        var movies = await _personalMovieService.GetPersonalMoviesAsync();
        var filteredmovies = new List<GetPersonalMovieDTO>();
        for (int i = (page - 1) * moviesPerPage; i < page * moviesPerPage; i++) {
            if (i == movies.Count) break;
            filteredmovies.Add(movies[i]);
        }


        var result = new GetPersonalMovieVM() {
            Movies = filteredmovies,
            TotalPages = (movies.Count % moviesPerPage == 0) ?
                        (movies.Count / moviesPerPage)
                     :
                        (movies.Count / moviesPerPage) + 1,
        };

        return Ok(result);
    }


    [HttpGet("GetAllPersonalMovies")]
    public async Task<IActionResult> GetAllPersonalMovies()
    {

        var movies = await _personalMovieService.GetPersonalMoviesAsync();
        var filteredmovies = new List<GetPersonalMovieDTO>();
        for (int i = 0; i < movies.Count; i++)
        {
            filteredmovies.Add(movies[i]);
        }
        return Ok(filteredmovies);
    }



    [HttpGet("GetMyMovies")]
    public async Task<IActionResult> GetMyMovies() {

        var list = await _personalMovieService.GetPersonalMoviesByUsername(User.FindFirst(ClaimTypes.Name)?.Value!);
        return Ok(list);
    }


    [HttpDelete("DeletePersonalMovie")]
    public async Task<IActionResult> DeletePersonalMovie([FromQuery] string movieId) {

        await _personalMovieService.DeletePersonalMovieAsync(movieId);
        return Ok();
    }


    [HttpGet("GetUserLikes")]
    public async Task<IActionResult> GetUserLikes([FromQuery] string movieId)
    {
        var list=await _personalMovieService.GetUserLikesAsync(movieId);
        return Ok(list);
    }

    [HttpGet("GetUserDislikes")]
    public async Task<IActionResult> GetUserDislikes([FromQuery] string movieId)
    {
        var list = await _personalMovieService.GetUserDislikesAsync(movieId);
        return Ok(list);
    }

    [HttpGet("GetUserViews")]
    public async Task<IActionResult> GetUserViews([FromQuery] string movieId)
    {
        var list = await _personalMovieService.GetUserViewsAsync(movieId);
        return Ok(list);
    }

    [HttpGet("GetUserComments")]
    public async Task<IActionResult> GetUserComments([FromQuery] string movieId)
    {
        var list = await _personalMovieService.GetUserCommentsAsync(movieId);
        return Ok(list);
    }






}