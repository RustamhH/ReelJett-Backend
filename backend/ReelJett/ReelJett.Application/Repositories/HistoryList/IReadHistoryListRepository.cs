using ReelJett.Application.Repositories.Common;
using ReelJett.Domain.Entities.Concretes;

namespace ReelJett.Application.Repositories;

public interface IReadHistoryListRepository : IReadGenericRepository<HistoryList> {

    // Methods

    Task<HistoryList?> GetByUsername(string username);
    Task<ICollection<MovieItem>?> GetMoviesByUsername(string username);
}
