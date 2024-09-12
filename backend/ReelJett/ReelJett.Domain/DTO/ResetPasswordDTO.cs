using System.ComponentModel.DataAnnotations;

namespace ReelJett.Domain.DTO;

public class ResetPasswordDTO {

    // Fields

    public string Password { get; set; }
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}
