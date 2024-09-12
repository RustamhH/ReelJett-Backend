using ReelJett.Domain.Entities.Concretes;

namespace ReelJett.Application.Services;

public interface IBaseMovieService {

    // Methods

    Task<int> SetViewCount(string movieId, string username);
    Task<Movie> SetLikeCount(string movieId, string username, bool isLikeButton);

}