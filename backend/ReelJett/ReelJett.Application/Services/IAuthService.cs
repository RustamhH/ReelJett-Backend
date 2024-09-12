using ReelJett.Domain.DTO;
using ReelJett.Domain.Helpers;
using Microsoft.AspNetCore.Http;
using ReelJett.Domain.ViewModels;
using ReelJett.Domain.Entities.Concretes;

namespace ReelJett.Application.Services;

public interface IAuthService {

    // Methods

    Task<int> ConfirmEmail(string token);
    Task RefreshLogin(string refreshToken);
    Task<LoginVM> Login(LoginDTO loginDTO, HttpResponse response);
    Task<int> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO);
    Task SetRefreshToken(User user, TokenCredentials refreshToken,HttpResponse response=null);
    Task<int> Register(RegisterDTO registerDTO, HttpResponse response);
    Task<int> ResetPassword(string token, ResetPasswordDTO resetPasswordDTO);
    Task<TokenCredentials?> RefreshToken(HttpResponse response, HttpRequest request);
}
