using System.ComponentModel.DataAnnotations;

namespace ReelJett.Domain.DTO;

public class LoginDTO {

    // Fields

    public string Username { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
}