using ReelJett.Domain.DTO;
using ReelJett.Application.Services;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;

namespace ReelJett.Persistence.Services;

public class CommentService : ICommentService {

    // Fields

    private readonly IReadCommentRepository _readCommentRepository;
    private readonly IWriteCommentRepository _writeCommentRepository;
    private readonly IReadMovieRepository _readRepo;
    private readonly IReadUserRepository _readUserrepo;
    private readonly IReadCommentLikesRepository _readCommentLikeRepository;
    private readonly IWriteCommentLikesRepository _writeCommentLikeRepository;

    // Constructor

    public CommentService(IReadCommentRepository readCommentRepository, IWriteCommentRepository writeCommentRepository, IReadMovieRepository readRepo,
        IReadUserRepository readUserrepo, IReadCommentLikesRepository readCommentLikeRepository, IWriteCommentLikesRepository writeCommentLikeRepository) {

        _readCommentRepository = readCommentRepository;
        _writeCommentRepository = writeCommentRepository;
        _readRepo = readRepo;
        _readUserrepo = readUserrepo;
        _readCommentLikeRepository = readCommentLikeRepository;
        _writeCommentLikeRepository = writeCommentLikeRepository;
    }

    public async Task<List<GetCommentDTO>> AddComment(string movieId,string content,string username) {

        var movie = await _readRepo.GetByIdAsync(movieId);
        var user = await _readUserrepo.GetUserByUserName(username);
        if (movie !=null && user != null) {
            var comment = new Comment() {
                Content = content,
                MovieId=movie.Id,
                LikeCount=0,
                UserId=user.Id,
            };
            await _writeCommentRepository.AddAsync(comment);
        }
        var list = await GetComments(movieId);
        return list;
    }

    public async Task DeleteUnwantedComment(string movieId, string commentId, string username)
    {
        var comment = await _readCommentRepository.GetByIdAsync(commentId);
        var movie = await _readRepo.GetByIdAsync(movieId);
        if(comment.MovieId==movieId && movie.PersonalMovie.User.UserName==username)
        {
            await _writeCommentRepository.DeleteAsync(comment);
        }
    }

    public async Task DeleteComment(string commentId, string username)
    {
        var comment = await _readCommentRepository.GetByIdAsync(commentId);
        if (comment.User.UserName == username)
        {
            await _writeCommentRepository.DeleteAsync(comment);
        }
    }

    public async Task<List<GetCommentDTO>> GetComments(string movieId) {

        var List = new List<GetCommentDTO>();
        var movie = await _readRepo.GetByIdAsync(movieId);
        if (movie != null) {
            foreach (var item in movie.Comments) {
                List.Add(new GetCommentDTO() {
                    Id=item.Id,
                    Content=item.Content,
                    ProfilePhoto=item.User.ProfilePhoto,
                    SendingDate=item.CreatedAt.ToString("dd.MM.yy HH:mm"),
                    Username=item.User.UserName,
                    LikeCount=item.LikeCount,
                });
            }
        }
        return List;
    }

    public async Task<int> SetCommentLikeCount(string commentId, string username) {
        // username is the liker
        // get commentby id , create a new CommentLike => commentId=commentId , userId=user.id
        // check if the comment is already liked

        var user = await _readUserrepo.GetUserByUserName(username);
        var comment = await _readCommentRepository.GetByIdAsync(commentId);
        if (user != null && comment != null) {

            var result=await _readCommentLikeRepository.GetByUserAndCommentId(user.Id,commentId);
            if (result == null)  { // first time liking
                var commentLike = new CommentLikes() {
                    CommentId=commentId,
                    UserId=user.Id,
                };
                comment.LikeCount += 1;
                await _writeCommentLikeRepository.AddAsync(commentLike);
            }
            else { // clicking again , removing the like
                comment.LikeCount -= 1;
                await _writeCommentLikeRepository.DeleteAsync(result.Id);
            }
            await _writeCommentRepository.UpdateAsync(comment);
        }

        return comment.LikeCount;
    }
}
