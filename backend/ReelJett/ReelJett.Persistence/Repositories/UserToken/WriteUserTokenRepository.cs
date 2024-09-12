using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class WriteUserTokenRepository : WriteGenericRepository<UserToken>, IWriteUserTokenRepository {

    // Constructor

    public WriteUserTokenRepository(ReelJettDbContext context) : base(context) { }

    // Methods
}
