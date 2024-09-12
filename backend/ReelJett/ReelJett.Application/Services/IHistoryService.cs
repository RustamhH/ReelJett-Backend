using ReelJett.Domain.Entities.Concretes;

namespace ReelJett.Application.Services;

public interface IHistoryService {

    // Methods

    Task<string> AddMovieToHistoryAsync(string username, string movieId);
    Task<ICollection<MovieItem>?> GetHistoryMoviesAsync(string username);
}