using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReelJett.Application.Services;
using ReelJett.Domain.ViewModels;
using System.Security.Claims;

namespace ReelJett.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HistoryController : ControllerBase {

    // Fields

    private readonly IHistoryService _historyService;

    // Constructor

    public HistoryController(IHistoryService historyService) {
        _historyService = historyService;
    }

    // Methods

    [Authorize]
    [HttpPost("AddMovieToHistory")]
    public async Task<IActionResult> AddMovieToHistory([FromQuery] string movieId) {

        if (movieId == null)
            return BadRequest("Movie Id are required!");

        var result = await _historyService.AddMovieToHistoryAsync(User.FindFirst(ClaimTypes.Name)?.Value!, movieId);
        if (result == "User not found") return BadRequest("User not found");
        else if (result == "Contains") return Ok("This movie already in history");
        else return Ok("Movie Added To History!");
    }

    [Authorize(Roles="Admin,User")]
    [HttpGet("GetHistoryMovies")]
    public async Task<IActionResult> GetHistoryMovies() {

        var movies = await _historyService.GetHistoryMoviesAsync(User.FindFirst(ClaimTypes.Name)?.Value!);

        if (movies == null) return NoContent();

        var moviesVM = movies.Select(m => 
            new HistoryVM() {
                Id = m.Movie.Id,
                Poster = m.Movie.Poster,
                Rating = m.Movie.Rating,
                Release_date = m.Movie.Year,
                Original_title = m.Movie.Title,
                ViewCount=m.Movie.ViewCount,
                LikeCount=m.Movie.LikeCount,
                DislikeCount=m.Movie.DislikeCount
            }
        );
        return Ok(moviesVM);
    }
}