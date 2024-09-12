using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class WriteCommentRepository : WriteGenericRepository<Comment>, IWriteCommentRepository {

    // Constructor

    public WriteCommentRepository(ReelJettDbContext context) : base(context) { }

    // Methods
}
