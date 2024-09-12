using ReelJett.Domain.DTO;
namespace ReelJett.Application.Services;

public interface IPersonalMovieService {

    // Methods

    Task UpdatePublishedMoviesAsync();
    Task DeletePersonalMovieAsync(string movieId);
    Task<List<GetPersonalMovieDTO>> GetPersonalMoviesAsync();
    Task<string> AddPersonalMovieAsync(AddPersonalMovieDTO entity, string username);
    Task<List<UserOperationDTO>> GetUserLikesAsync(string movieId);
    Task<List<UserOperationDTO>> GetUserViewsAsync(string movieId);
    Task<List<UserOperationDTO>> GetUserDislikesAsync(string movieId);
    Task<List<UserOperationDTO>> GetUserCommentsAsync(string movieId);
    Task<List<GetMyMoviesDTO>> GetPersonalMoviesByUsername(string username);
}