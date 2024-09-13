using ReelJett.Domain.DTO;
using ReelJett.Domain.Entities.Concretes;

namespace ReelJett.Application.Services;

public interface IBaseMovieService {

    // Methods

    Task<int> SetViewCount(string movieId, string username);
    Task<LikeDTO> SetLikeCount(string movieId, string username, bool isLikeButton);

}