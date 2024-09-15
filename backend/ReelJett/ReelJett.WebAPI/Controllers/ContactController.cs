using ReelJett.Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using ReelJett.Application.Services;

namespace ReelJett.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase {

    // Fields

    private readonly IEmailService _emailService;

    // Constructor

    public ContactController(IEmailService emailService) {

        _emailService = emailService;
    }

    // Methods

    [HttpPost("SendEmailContact")]
    public async Task<IActionResult> SendEmailContact([FromBody] SendEmailContactDTO sendEmailContactDTO) {
        try
        {
            _emailService.from = new System.Net.Mail.MailAddress(sendEmailContactDTO.Email);
            var result = await _emailService.sendMailAsync("reeljett@gmail.com", sendEmailContactDTO.Subject, sendEmailContactDTO.Body, true);
            return Ok(result);
        }
        catch (Exception)
        {
            return Ok(false);
        }
        
        
    }

}
