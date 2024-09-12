using ReelJett.Domain.Entities.Concretes;
using ReelJett.Application.Repositories.Common;

namespace ReelJett.Application.Repositories;

public interface IReadCommentLikesRepository:IReadGenericRepository<CommentLikes> {

    //Methods

    Task<CommentLikes> GetByUserAndCommentId(string userId,string commentId);
}
