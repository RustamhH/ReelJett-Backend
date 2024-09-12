using ReelJett.Domain.DTO;

namespace ReelJett.Application.Services;

public interface IFavouriteService {

    // Methods

    Task DeleteFromFavourites(string movieId);
    Task<int> AddToFavourites(string username, string movieId);
    Task<List<string>> GetFavouriteProfessionalMovies(string username);
    Task<List<GetPersonalMovieDTO>> GetFavouritePersonalMovies(string username);
}
