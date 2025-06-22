    using ReelJett.Domain.DTO;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ReelJett.Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace ReelJett.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase {

    // Fields

    private readonly IAccountService _accountService;

    // Constructor 

    public AccountController(IAccountService accountService) { 
        _accountService = accountService;
    }

    // Methods

    //[Authorize]
    [HttpPut("UpdateAccount")]
    public async Task<IActionResult> UpdateAccount(UpdateAccountDTO updateAccountDTO) {

        var result = await _accountService.UpdateAccount(User.FindFirst(ClaimTypes.Name)?.Value!, updateAccountDTO,Response);
        if (result == 200) return Ok("Succeded");
        else if (result == 404) return NotFound("User not found");
        else if (result == 400) return BadRequest("Password is wrong");
        else return BadRequest("Repassword token expired");
    }

    //[Authorize]
    [HttpGet("GetAccountData")]
    public async Task<IActionResult> GetAccountData() {

        var result = await _accountService.GetAccountData(User.FindFirst(ClaimTypes.Name)?.Value!);
        return Ok(result);
    }
}