using ReelJett.Application.Services;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Domain.DTO;

namespace ReelJett.Persistence.Services;

public class BaseMovieService:IBaseMovieService {

    // Fields

    private readonly IReadMovieRepository _readRepo;
    private readonly IWriteMovieRepository _writeRepo;
    private readonly IReadUserRepository _readUserrepo;
    private readonly IReadUserLikesRepository _readLikerepo;
    private readonly IReadUserViewsRepository _readViewrepo;
    private readonly IWriteUserLikesRepository _writeLikerepo;
    private readonly IWriteUserViewsRepository _writeViewrepo;
    
    // Constructor

    public BaseMovieService(IReadUserLikesRepository readLikerepo, IReadUserViewsRepository readViewrepo, IWriteUserLikesRepository writeLikerepo,
        IWriteUserViewsRepository writeViewrepo, IReadMovieRepository readRepo, IWriteMovieRepository writeRepo, IReadUserRepository readUserrepo) {

        _readLikerepo = readLikerepo;
        _readViewrepo = readViewrepo;
        _writeLikerepo = writeLikerepo;
        _writeViewrepo = writeViewrepo;
        _readRepo = readRepo;
        _writeRepo = writeRepo;
        _readUserrepo = readUserrepo;
    }

    // Methods

    public async Task<LikeDTO> SetLikeCount(string movieId, string username, bool isLikeButton) {

        var movie = await _readRepo.GetByIdAsync(movieId);
        var user = await _readUserrepo.GetUserByUserName(username);
        if (movie != null && user != null) {

            var result = await _readLikerepo.GetByUserId(user.Id, movieId); // buttondan artiq istifade olunub 
            if (result != null) {
                if (result.IsLike)  {
                    if (isLikeButton) {
                        if (movie.LikeCount != 0) {
                            movie.LikeCount -= 1;
                            await _writeLikerepo.DeleteAsync(result.Id);
                        }
                    }
                    else {

                        movie.DislikeCount += 1;
                        movie.LikeCount -= 1;
                        result.IsLike = false;
                        result.LastModifiedAt = DateTime.Now;
                    }
                }
                else {
                    if (isLikeButton) {

                        // dislike-1 // like+1
                        movie.DislikeCount -= 1;
                        movie.LikeCount += 1;
                        result.IsLike = true;
                        result.LastModifiedAt = DateTime.Now;
                    }
                    else {
                        if (movie.DislikeCount != 0) {
                            movie.DislikeCount -= 1;
                            await _writeLikerepo.DeleteAsync(result.Id);
                        }
                    }
                }
                
            }
            else {

                var userLike = new UserLikes() {

                    UserId = user.Id,
                    MovieId = movieId,
                    IsLike = isLikeButton,
                };

                await _writeLikerepo.AddAsync(userLike);
                if (isLikeButton) movie.LikeCount += 1;
                else movie.DislikeCount += 1;
            }
            await _writeRepo.UpdateAsync(movie);
            return new LikeDTO() {LikeCount=movie.LikeCount,DislikeCount=movie.DislikeCount };
        }
        else return new LikeDTO();
    }

    public async Task<int> SetViewCount(string movieId, string username) {

        var movie = await _readRepo.GetByIdAsync(movieId);
        var user = await _readUserrepo.GetUserByUserName(username);
        if (movie != null && user!=null) {

            var result = await _readViewrepo.GetByUserId(user.Id, movieId);
            if (result == null) {

                var userView = new UserViews() {
                    UserId = user.Id,
                    MovieId = movieId,
                };
                await _writeViewrepo.AddAsync(userView);
                movie.ViewCount += 1;
            }
            await _writeRepo.UpdateAsync(movie);
            return movie.ViewCount;
        }
        else return 0;
    }
}