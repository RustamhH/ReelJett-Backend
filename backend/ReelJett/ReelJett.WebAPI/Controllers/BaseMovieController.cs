using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ReelJett.Application.Services;

namespace ReelJett.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseMovieController : ControllerBase {
    
    // Fields
    
    private readonly IBaseMovieService _baseMovieService;

    // Constructor

    public BaseMovieController(IBaseMovieService baseMovieService) {
        _baseMovieService = baseMovieService;
    }

    [HttpPost("SetViewCount")]
    public async Task<IActionResult> SetViewCount([FromQuery] string movieId) {

        var result = await _baseMovieService.SetViewCount(movieId, User.FindFirst(ClaimTypes.Name)?.Value!);
        return Ok(result);
    }

    [HttpPost("SetLikeCount")]
    public async Task<IActionResult> SetLikeCount([FromQuery] string movieId, bool isLikeButton) {

        var result = await _baseMovieService.SetLikeCount(movieId, User.FindFirst(ClaimTypes.Name)?.Value!, isLikeButton);
        if (result != null) return Ok(result);
        return BadRequest();
    }

    



}
