using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories.CommentLikes;

public class WriteCommentLikesRepository : WriteGenericRepository<Domain.Entities.Concretes.CommentLikes>, IWriteCommentLikesRepository {

    // Constructor

    public WriteCommentLikesRepository(ReelJettDbContext context) : base(context) { }
}
