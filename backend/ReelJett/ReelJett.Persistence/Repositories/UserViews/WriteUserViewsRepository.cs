using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

public class WriteUserViewsRepository : WriteGenericRepository<UserViews>, IWriteUserViewsRepository {

    // Constructor

    public WriteUserViewsRepository(ReelJettDbContext context) : base(context) { }
}
