using ReelJett.Domain.DTO;
using ReelJett.Domain.ViewModels;
using ReelJett.Application.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Domain.Helpers;
using Microsoft.AspNetCore.Http;
using Azure;

namespace ReelJett.Persistence.Services;

public class AccountService : IAccountService {

    // Fields
    public HttpResponse Response { get; set; }
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;
    private readonly UserManager<User> _userManager;
    private readonly IReadUserRepository _readUserRepository;
    private readonly IWriteUserRepository _writeUserRepository;
    private readonly IWriteUserTokenRepository _writeUserTokenRepository;

    // Constructor

    public AccountService(IReadUserRepository readUserRepository, IWriteUserRepository writeUserRepository, UserManager<User> userManager,
        ITokenService tokenService, IWriteUserTokenRepository writeUserTokenRepository, IAuthService authService) { 

        _authService = authService;
        _userManager = userManager;
        _tokenService = tokenService;
        _readUserRepository = readUserRepository;
        _writeUserRepository = writeUserRepository;
        _writeUserTokenRepository = writeUserTokenRepository;
    }

    // Methods

    public async Task<int> UpdateAccount(string username, UpdateAccountDTO updateAccountDTO,HttpResponse response) {

        var user = await _readUserRepository.GetUserByUserName(username);

        if (user == null)
            return 404;

        if (updateAccountDTO.ProfilePhoto != user.ProfilePhoto) 
        {
            byte[] array=Convert.FromBase64String(updateAccountDTO.ProfilePhoto);
            await BlobHandler.DeleteBlob(user.ProfilePhoto);
            user.ProfilePhoto = await BlobHandler.UploadToBlobStorage(array);
        } 
        user.Email = updateAccountDTO.Email;
        user.Lastname = updateAccountDTO.Lastname;
        user.Firstname = updateAccountDTO.Firstname;



        if (user.UserName!=updateAccountDTO.Username) // username changed
        {
            user.UserName = updateAccountDTO.Username;
            await _userManager.UpdateNormalizedUserNameAsync(user);
            var token = _tokenService.CreateRefreshToken();
            await _authService.SetRefreshToken(user,token,response);
            await _authService.RefreshLogin(token.Token);
        }



        await _writeUserRepository.UpdateAsync(user);

        var isSamePassword = await _userManager.CheckPasswordAsync(user, updateAccountDTO.Password);

        if (isSamePassword || updateAccountDTO.Password.IsNullOrEmpty()) return 200;

        var repasswordtoken = await _tokenService.CreateRepasswordToken(user!);

        var userForgotPasswordToken = new UserToken() {
            UserId = user.Id,
            Name = "RepasswordToken",
            Token = repasswordtoken.Token,
            ExpireTime = repasswordtoken.ExpireTime,
        };

        await _writeUserTokenRepository.AddAsync(userForgotPasswordToken);
        
        var resetPasswordDTO = new ResetPasswordDTO() { Password = updateAccountDTO.Password, ConfirmPassword = updateAccountDTO.Password };
        var result = await _authService.ResetPassword(userForgotPasswordToken.Token, resetPasswordDTO);

        return result;
    }

    public async Task<GetAccountData> GetAccountData(string username) {

        var getAccountData = new GetAccountData();
        var user = await _readUserRepository.GetUserByUserName(username);

        if (user == null) getAccountData.Error = "User not found";
        else {
            getAccountData.Password = "";
            getAccountData.Email = user.Email!;
            getAccountData.Lastname = user.Lastname;
            getAccountData.Username = user.UserName!;
            getAccountData.Firstname = user.Firstname;
            getAccountData.ProfilePhoto=user.ProfilePhoto;
        }

        return getAccountData;
    }
}
