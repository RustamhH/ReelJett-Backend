using ReelJett.Domain.DTO;

namespace ReelJett.Application.Services;

public interface ICommentService {

    // Methods

    Task<List<GetCommentDTO>> AddComment(string movieId, string content, string username);
    Task<List<GetCommentDTO>> GetComments(string movieId);
    Task<int> SetCommentLikeCount(string commentId, string username);
    Task DeleteUnwantedComment(string commentId,string movieId,string username);

}