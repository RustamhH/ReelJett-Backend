using Microsoft.AspNetCore.Http;
using ReelJett.Domain.DTO;
using ReelJett.Domain.ViewModels;

namespace ReelJett.Application.Services;

public interface IAccountService {

    // Methods

    Task<int> UpdateAccount(string username, UpdateAccountDTO updateAccountDTO,HttpResponse response);
    Task<GetAccountData> GetAccountData(string username);
}