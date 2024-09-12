using Microsoft.EntityFrameworkCore;
using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class ReadHistoryListRepository : ReadGenericRepository<HistoryList>, IReadHistoryListRepository {

    // Constructor

    public ReadHistoryListRepository(ReelJettDbContext context) : base(context) { }

    // Methods

    public async Task<ICollection<MovieItem>?> GetMoviesByUsername(string username) {
        return (await _table.Where(p => p.User.UserName == username).FirstOrDefaultAsync())?.Movies;
    }

    public async Task<HistoryList?> GetByUsername(string username) {
        return await _table.Where(p => p.User.UserName == username).FirstOrDefaultAsync();
    }
}
