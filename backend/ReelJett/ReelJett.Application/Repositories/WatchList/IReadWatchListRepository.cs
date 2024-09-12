using ReelJett.Domain.Entities.Concretes;
using ReelJett.Application.Repositories.Common;

namespace ReelJett.Application.Repositories;

public interface IReadWatchListRepository : IReadGenericRepository<WatchList> {

    // Methods

    Task<WatchList?> GetWatchListByUserId(string userId);
}
