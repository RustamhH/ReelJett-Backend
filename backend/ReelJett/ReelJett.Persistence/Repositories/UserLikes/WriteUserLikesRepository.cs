using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class WriteUserLikesRepository : WriteGenericRepository<UserLikes>, IWriteUserLikesRepository {

    //Constructor

    public WriteUserLikesRepository(ReelJettDbContext context) : base(context) { }
}
