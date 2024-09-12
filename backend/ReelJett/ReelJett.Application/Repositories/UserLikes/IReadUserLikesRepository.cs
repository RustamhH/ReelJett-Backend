using ReelJett.Domain.Entities.Concretes;
using ReelJett.Application.Repositories.Common;

namespace ReelJett.Application.Repositories;

public interface IReadUserLikesRepository : IReadGenericRepository<UserLikes> {

    // Methods

    Task<UserLikes?> GetByUserId(string userId, string movieId);
}
