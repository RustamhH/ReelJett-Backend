using ReelJett.Domain.Entities.Concretes;
using ReelJett.Application.Repositories.Common;

namespace ReelJett.Application.Repositories;

public interface IReadUserTokenRepository : IReadGenericRepository<UserToken>{

    // Methods

    Task<UserToken?> GetConfirmEmailToken(string token);
    Task<UserToken?> GetResetPasswordToken(string token);
    Task<User?> GetUserByRefreshToken(string refreshToken);
    Task<User?> GetUserByRePasswordToken(string rePasswordToken);
    Task<User?> GetUserByConfirmEmailToken(string confirmEmailToken);
}
