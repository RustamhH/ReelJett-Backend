using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ReelJett.Application.Services;

namespace ReelJett.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FavouriteController : ControllerBase {

    // Fields

    private readonly IFavouriteService _favouriteService;

    // Constructor

    public FavouriteController(IFavouriteService favouriteService) {

        _favouriteService = favouriteService;
    }

    // Methods

    [HttpPost("AddToFavourites")]
    public async Task<IActionResult> AddToFavourites([FromQuery] string movieId) {

        var statusCode = await _favouriteService.AddToFavourites(User.FindFirst(ClaimTypes.Name)?.Value!, movieId);
        return Ok(statusCode);
    }

    [HttpDelete("DeleteFromFavourites")]
    public async Task<IActionResult> DeleteFromFavourites([FromQuery] string movieId) {

        await _favouriteService.DeleteFromFavourites(movieId);
        return Ok();
    }

    [HttpGet("GetFavouritePersonalMovies")]
    public async Task<IActionResult> GetFavouritePersonalMovies() {

        var list = await _favouriteService.GetFavouritePersonalMovies(User.FindFirst(ClaimTypes.Name)?.Value!);
        return Ok(list);
    }

    [HttpGet("GetFavouriteProfessionalMovies")]
    public async Task<IActionResult> GetFavouriteProfessionalMovies() {

        var list = await _favouriteService.GetFavouriteProfessionalMovies(User.FindFirst(ClaimTypes.Name)?.Value!);
        return Ok(list);
    }
}
