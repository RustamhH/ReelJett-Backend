using Microsoft.EntityFrameworkCore;
using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories.CommentLikes;

public class ReadCommentLikesRepository : ReadGenericRepository<ReelJett.Domain.Entities.Concretes.CommentLikes>, IReadCommentLikesRepository {

    // Constructor

    public ReadCommentLikesRepository(ReelJettDbContext context) : base(context) { }

    // Methods

    public async Task<Domain.Entities.Concretes.CommentLikes> GetByUserAndCommentId(string userId, string commentId) {
        return await _table.FirstOrDefaultAsync(c => c.UserId == userId && c.CommentId == commentId);
    }
}
