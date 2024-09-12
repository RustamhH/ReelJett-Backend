using System.Linq.Expressions;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Application.Repositories.Common;

namespace ReelJett.Application.Repositories;

public interface IReadMovieItemRepository : IReadGenericRepository<MovieItem> {

    // Methods

    Task<MovieItem?> GetByMovieId(string movieId);
    Task<MovieItem?> GetByWatchListId(string watchListId);
    Task<MovieItem?> GetByHistoryListId(string historyListId);
    Task<IQueryable> GetByExpressionAsync(Expression<Func<MovieItem, bool>> expression);
}