using ReelJett.Domain.Helpers;
using ReelJett.Domain.Entities.Concretes;

namespace ReelJett.Application.Services;

public interface ITokenService {
    TokenCredentials CreateRefreshToken();
    TokenCredentials CreateConfirmEmailToken();
    Task<TokenCredentials> CreateAccessToken(User user);
    Task<TokenCredentials> CreateRepasswordToken(User user);
}
