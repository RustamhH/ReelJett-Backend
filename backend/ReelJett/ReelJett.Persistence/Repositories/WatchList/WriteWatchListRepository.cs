using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class WriteWatchListRepository : WriteGenericRepository<WatchList>, IWriteWatchListRepository {

    // Constructor

    public WriteWatchListRepository(ReelJettDbContext context) : base(context) {

    }

    // Methods
}
