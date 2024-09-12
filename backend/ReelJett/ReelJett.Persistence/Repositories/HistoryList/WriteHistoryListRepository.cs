using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class WriteHistoryListRepository : WriteGenericRepository<HistoryList>, IWriteHistoryListRepository {

    // Constructor

    public WriteHistoryListRepository(ReelJettDbContext context) : base(context) { }

    // Methods
}