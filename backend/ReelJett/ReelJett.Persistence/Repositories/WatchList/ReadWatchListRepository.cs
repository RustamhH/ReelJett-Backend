using Microsoft.EntityFrameworkCore;
using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class ReadWatchListRepository : ReadGenericRepository<WatchList>, IReadWatchListRepository {

    // Constructor

    public ReadWatchListRepository(ReelJettDbContext context) : base(context) {

    }

    // Methods

    public async Task<WatchList?> GetWatchListByUserId(string userId) {
        return await _table.FirstOrDefaultAsync(watchlist => watchlist.UserId == userId);
    }
}