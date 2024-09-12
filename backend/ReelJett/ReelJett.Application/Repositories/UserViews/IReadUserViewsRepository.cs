using ReelJett.Domain.Entities.Concretes;
using ReelJett.Application.Repositories.Common;

namespace ReelJett.Application.Repositories;

public interface IReadUserViewsRepository : IReadGenericRepository<UserViews> {

    // Methods

    Task<UserViews?> GetByUserId(string userId, string movieId);
}
