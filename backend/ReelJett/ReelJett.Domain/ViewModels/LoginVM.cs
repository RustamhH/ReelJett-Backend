using ReelJett.Domain.Helpers;

namespace ReelJett.Domain.ViewModels;

public class LoginVM {

    // Fields

    public string? Error { get; set; }
    public string ProfilePhoto { get; set; }
    public List<string> Roles { get; set; }
    public TokenCredentials AccessToken { get; set; }
}
