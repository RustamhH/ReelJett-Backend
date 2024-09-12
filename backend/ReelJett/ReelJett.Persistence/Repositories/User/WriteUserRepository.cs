using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class WriteUserRepository : WriteGenericRepository<User>, IWriteUserRepository {

    // Constructor

    public WriteUserRepository(ReelJettDbContext context) : base(context) { }

    // Methods
}
