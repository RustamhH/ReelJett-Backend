using ReelJett.Domain.DTO;
using ReelJett.Domain.Helpers;
using Microsoft.AspNetCore.Http;
using ReelJett.Domain.ViewModels;
using ReelJett.Application.Services;
using Microsoft.AspNetCore.Identity;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;

namespace ReelJett.Persistence.Services;

public class AuthService : IAuthService {

    // Fields

    public HttpResponse Response { get; set; }
    private readonly IEmailService _emailService;
    private readonly ITokenService _tokenService;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IReadUserRepository _readUserRepository;
    private readonly IWriteUserRepository _writeUserRepository;
    private readonly IReadUserTokenRepository _readUserTokenRepository;
    private readonly IWriteUserTokenRepository _writeUserTokenRepository;

    // Constructor

    public AuthService(
        UserManager<User> userManager, SignInManager<User> signInManager,
        IReadUserRepository readUserRepository, IWriteUserRepository writeUserRepository, ITokenService tokenService,
        IEmailService emailService, IReadUserTokenRepository readUserTokenRepository, IWriteUserTokenRepository writeUserTokenRepository) {

        _userManager = userManager;
        _tokenService = tokenService;
        _emailService = emailService;
        _signInManager = signInManager;
        _readUserRepository = readUserRepository;
        _writeUserRepository = writeUserRepository;
        _readUserTokenRepository = readUserTokenRepository;
        _writeUserTokenRepository = writeUserTokenRepository;
    }


    // Methods

    public async Task RefreshLogin(string refreshToken) {
        var user = await _readUserTokenRepository.GetUserByRefreshToken(refreshToken);
        if (user != null) await _signInManager.RefreshSignInAsync(user);
    }

    public async Task<LoginVM> Login(LoginDTO loginDTO, HttpResponse response) {

        var error = "";
        if (Response == null) Response = response;

        var user = await _userManager.FindByNameAsync(loginDTO.Username);
        
        if (user is null)
        {
            error = "Username is wrong";
            return new LoginVM() { Error = error };
        }
        else if (!user.EmailConfirmed)
        {
            error = "Email not confirmed";
            return new LoginVM() { Error = error };
        }

        var roles = (await _userManager.GetRolesAsync(user)).ToList();
        var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);
        var accesstoken = await _tokenService.CreateAccessToken(user);
        var refreshtoken = _tokenService.CreateRefreshToken();

        await SetRefreshToken(user, refreshtoken);
        var loginVM = new LoginVM() {
            Roles = roles,
            AccessToken = accesstoken,
            ProfilePhoto = user.ProfilePhoto,
            Error = error.Length != 0 ? error : null
        };

        if (result.Succeeded)
            return loginVM;
        else {
            loginVM.Error = "Password is wrong.";
            return loginVM;
        }
    }

    public async Task<int> Register(RegisterDTO registerDTO, HttpResponse response) {

        if (Response == null) Response = response;

        var user = await _readUserRepository.GetUserByUserName(registerDTO.Username);
        if (user is not null)
            return 409;

        user = await _readUserRepository.GetUserByEmail(registerDTO.Email);
        if (user is not null)
            return 409;

        if (registerDTO.Password != registerDTO.ConfirmPassword) return -1;

        var newUser = await CreateNewUser(registerDTO);
        return newUser;
    }

    // Helper Method. SetRefreshToken
    public async Task SetRefreshToken(User user, TokenCredentials refreshToken,HttpResponse response=null) {

        

        var cookieOptions = new CookieOptions() {
            HttpOnly = true,
            Expires = refreshToken.ExpireTime
        };
        if(response!=null)
        {
            Response = response;
        }

        Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

        var tokenstodelete = user.UserTokens.Where(p => p.Name == "RefreshToken").Where(p => p.IsDeleted == false);
        foreach (var token in tokenstodelete)
            token.IsDeleted = true;

        var refreshUserToken = new UserToken() {
            UserId = user.Id,
            Name = "RefreshToken",
            Token = refreshToken.Token,
            ExpireTime = refreshToken.ExpireTime.AddHours(4)
        };
        await _writeUserTokenRepository.AddAsync(refreshUserToken);
    }

    public async Task<TokenCredentials?> RefreshToken(HttpResponse response, HttpRequest Request) {

        if (Response == null) Response = response;

        var refreshToken = Request.Cookies["refreshToken"];
        if (string.IsNullOrEmpty(refreshToken))
            return null;

        var user = await _readUserTokenRepository.GetUserByRefreshToken(refreshToken);
        if (user is null)
            return null;


        var accessToken = await _tokenService.CreateAccessToken(user);
        var refreshTokenObj = _tokenService.CreateRefreshToken();

        await _writeUserRepository.UpdateAsync(user);
        await SetRefreshToken(user, refreshTokenObj);

        return accessToken;
    }

    private async Task<int> CreateNewUser(RegisterDTO registerDTO) {

        var newUser = new User();
        if (registerDTO.ProfilePhoto is null) {
            newUser = new User() {
                Firstname = registerDTO.Firstname,
                Lastname = registerDTO.Lastname,
                UserName = registerDTO.Username,
                Email = registerDTO.Email,
                ProfilePhoto = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b5/Windows_10_Default_Profile_Picture.svg/1024px-Windows_10_Default_Profile_Picture.svg.png"
            };
        }
        else {
            newUser = new User() {
                Firstname = registerDTO.Firstname,
                Lastname = registerDTO.Lastname,
                UserName = registerDTO.Username,
                Email = registerDTO.Email,
                ProfilePhoto = registerDTO.ProfilePhoto
            };
        }

        var registerResult = await _userManager.CreateAsync(newUser, registerDTO.Password);

        if (registerResult.Succeeded) {
            var user = await _userManager.FindByNameAsync(newUser.UserName);
            await _userManager.AddToRoleAsync(user!, "User");

            await SendConfirmEmail(registerDTO, newUser);

            return 200;
        }
        else return 400;
    }

    private async Task SendConfirmEmail(RegisterDTO registerDTO, User newUser) {

        var confirmEmailToken = _tokenService.CreateConfirmEmailToken();
        var actionUrl = $@"http://localhost:5124/api/Auth/ConfirmEmail?token={confirmEmailToken.Token}";
        var result = await _emailService.sendMailAsync(registerDTO.Email, "Confirm Your Email", $"Confirm your password by <a href='{actionUrl}'>clicking here</a>.", true);

        var userConfirmEmailToken = new UserToken() {
            UserId = newUser.Id,
            Name = "ConfirmEmailToken",
            Token = confirmEmailToken.Token,
            ExpireTime = confirmEmailToken.ExpireTime,
        };
        await _writeUserTokenRepository.AddAsync(userConfirmEmailToken);
    }

    // Confirm Email Method
    public async Task<int> ConfirmEmail(string token) {

        var user = await _readUserTokenRepository.GetUserByConfirmEmailToken(token);
        if (user is null)
            return 404; // User not found

        var confirmEmailToken = await _readUserTokenRepository.GetConfirmEmailToken(token);
        if (confirmEmailToken.ExpireTime < DateTime.UtcNow) {
            confirmEmailToken.IsDeleted = true;
            return 405; // ConfirmEmailToken expired
        }

        confirmEmailToken.IsDeleted = true;
        await _writeUserTokenRepository.UpdateAsync(confirmEmailToken);

        user.EmailConfirmed = true;
        await _writeUserRepository.UpdateAsync(user);

        return 200;
    }

    // Forgot Password
    public async Task<int> ForgotPassword(ForgotPasswordDTO forgotPasswordDTO) {

        var user = await _readUserRepository.GetUserByEmail(forgotPasswordDTO.Email);
        if (user is null)
            return 404; // BadRequest("User not found");

        var tokenstodelete = user.UserTokens!.Where(p => p.Name == "RepasswordToken").Where(p => p.IsDeleted == false);
        foreach (var token in tokenstodelete)
            token.IsDeleted = true;

        var forgotPasswordToken = await _tokenService.CreateRepasswordToken(user);
        var actionUrl = $@"https://localhost:5173/resetpassword?token={forgotPasswordToken.Token}";
        var result = await _emailService.sendMailAsync(forgotPasswordDTO.Email, "Reset Your Password", $"Reset your password by <a href='{actionUrl}'>clicking here</a>.", true);

        var userForgotPasswordToken = new UserToken() {
            UserId = user.Id,
            Name = "RepasswordToken",
            Token = forgotPasswordToken.Token,
            ExpireTime = forgotPasswordToken.ExpireTime,
        };
        await _writeUserTokenRepository.AddAsync(userForgotPasswordToken);

        return 200;
    }

    // Reset Password
    public async Task<int> ResetPassword(string token, ResetPasswordDTO resetPasswordDTO) {

        var user = await _readUserTokenRepository.GetUserByRePasswordToken(token);
        if (user is null)
            return 404; // User not found

        var rePasswordToken = await _readUserTokenRepository.GetResetPasswordToken(token);
        if (rePasswordToken.ExpireTime < DateTime.UtcNow)
            return 405; // expired

        var result = await _userManager.ResetPasswordAsync(user, token, resetPasswordDTO.Password);
        if (result.Succeeded) {
            rePasswordToken.IsDeleted = true;
            await _writeUserRepository.UpdateAsync(user);
            await _writeUserRepository.SaveChangeAsync();
            await _writeUserTokenRepository.UpdateAsync(rePasswordToken);
            return 200;
        }
        return 400;
    }
}