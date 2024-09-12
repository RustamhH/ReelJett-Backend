using ReelJett.Domain.Entities.Concretes;
using ReelJett.Application.Repositories.Common;

namespace ReelJett.Application.Repositories;

public interface IReadUserRepository : IReadGenericRepository<User> {

    // Methods

    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserByUserName(string userName);
}
