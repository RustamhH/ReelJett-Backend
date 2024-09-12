using System.ComponentModel.DataAnnotations;

namespace ReelJett.Domain.DTO;

public class UpdateAccountDTO {

    // Fields

    public string Firstname { get; set; }
    public string Lastname { get; set; }

    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public string ProfilePhoto { get; set; }
}