using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class ReadMovieItemRepository : ReadGenericRepository<MovieItem>, IReadMovieItemRepository {

    // Constructor

    public ReadMovieItemRepository(ReelJettDbContext context) : base(context) { }

    // Methods

    public async Task<IQueryable> GetByExpressionAsync(Expression<Func<MovieItem, bool>> expression) {
        return _table.Where(expression);
    }

    public Task<MovieItem?> GetByHistoryListId(string historyListId) {
        throw new NotImplementedException();
    }

    public async Task<MovieItem?> GetByMovieId(string movieId) {
        return await _table.FirstOrDefaultAsync(m => m.MovieId == movieId);
    }

    public async Task<MovieItem?> GetByWatchListId(string watchListId) {
        return await _table.FirstOrDefaultAsync(m => m.WatchListId == watchListId);
    }
}