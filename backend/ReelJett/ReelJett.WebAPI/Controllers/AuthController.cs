using ReelJett.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using ReelJett.Application.Services;

namespace ReelJett.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase {

    // Fields

    private readonly IAuthService _authService;

    // Constructor

    public AuthController(IAuthService authService) {
        _authService = authService;
    }

    // Methods

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO) {

        var result = await _authService.Register(registerDTO, Response);
        if (result == 409) return BadRequest("User already exists.");
        else if (result == 200) return Ok("User created succesfully.");
        else if (result == -1) return BadRequest("Password is not same with Confirm password.");
        else return BadRequest("User can't be created.");
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO) {
        
        var result = await _authService.Login(loginDTO, Response);
        if (result.Error != null) return BadRequest(result.Error);
        else return Ok(result);
    }

    [HttpPost("SetRefreshToken")]
    public async Task<IActionResult> SetRefreshToken() {

        var result = await _authService.RefreshToken(Response, Request);
        if (result == null) return BadRequest("Invalid RefreshToken.");
        else return Ok(result);
    }

    [HttpGet("RefreshLogin")]
    public async Task<IActionResult> RefreshLogin() {
        Request.Cookies.TryGetValue("refreshToken", out var refreshToken);
        await _authService.RefreshLogin(refreshToken!);
        return Ok("Login refreshed");
    }

    [HttpGet("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmail([FromQuery] string token) {

        var result = await _authService.ConfirmEmail(token);
        if (result == 404) return BadRequest("User not found.");
        else if (result == 405) return BadRequest("ConfirmEmailToken expired");
        else return Ok("Email confirmed");
    }

    [HttpPost("ForgotPassword")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO forgotPasswordDTO) {

        var result = await _authService.ForgotPassword(forgotPasswordDTO);
        if (result == 404) return BadRequest("User not found.");
        else return Ok("Email has been sent");
    }

    [HttpPost("ResetPassword")]
    public async Task<IActionResult> ResetPassword(string token,[FromBody]ResetPasswordDTO forgotPasswordDTO) {

        var result = await _authService.ResetPassword(token,forgotPasswordDTO);
        if (result == 404) return BadRequest("User not found.");
        else return Ok("Password Updated");
    }
}