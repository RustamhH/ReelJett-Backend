using Microsoft.EntityFrameworkCore;
using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class ReadUserViewsRepository : ReadGenericRepository<UserViews>, IReadUserViewsRepository {

    // Constructor

    public ReadUserViewsRepository(ReelJettDbContext context) : base(context) { }

    // Methods

    public async Task<UserViews?> GetByUserId(string userId, string movieId) {
        return await _table.FirstOrDefaultAsync(p => p.UserId == userId && p.MovieId == movieId);
    }
}
