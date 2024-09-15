using ReelJett.Domain.DTO;
using ReelJett.Application.Services;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;

namespace ReelJett.Persistence.Services;

public class FavouriteService : IFavouriteService {

    // Fields

    private readonly IReadMovieRepository _readRepo;
    private readonly IReadUserRepository _readUserrepo;
    private readonly IReadWatchListRepository _readFavRepo;
    private readonly IWriteWatchListRepository _writeFavRepo;
    private readonly IReadMovieItemRepository _readMovieItemRepo;
    private readonly IWriteMovieItemRepository _writeMovieItemRepo;

    // Constructor

    public FavouriteService(IReadWatchListRepository readFavRepo, IWriteWatchListRepository writeFavRepo, IReadMovieItemRepository readMovieItemRepo,
        IWriteMovieItemRepository writeMovieItemRepo, IReadMovieRepository readRepo, IReadUserRepository readUserrepo) {

        _readRepo = readRepo;
        _readFavRepo = readFavRepo;
        _writeFavRepo = writeFavRepo;
        _readUserrepo = readUserrepo;
        _readMovieItemRepo = readMovieItemRepo;
        _writeMovieItemRepo = writeMovieItemRepo;
    }

    // Methods

    public async Task<int> AddToFavourites(string username, string movieId) {

        var movie = await _readRepo.GetByIdAsync(movieId);
        var user = await _readUserrepo.GetUserByUserName(username);
        if (movie != null && user != null) { // create

            var favList = await _readFavRepo.GetWatchListByUserId(user.Id);
            if (favList != null) {

                // userin artiq watchListi var . Sadece movieItem yaradib watchList id verilir
                var watchListObj = await _readMovieItemRepo.GetByWatchListId(favList.Id);
                var movieObj = await _readMovieItemRepo.GetByMovieId(movieId);
                
                if (movieObj!= null && watchListObj != null && movieObj.WatchListId == favList.Id) {
                    return 409;
                    // bu movie artiq watchliste elave olunub
                }
                else {

                    var movieItem = new MovieItem() {
                        MovieId = movieId,
                        WatchListId = favList.Id,
                    };
                    await _writeMovieItemRepo.AddAsync(movieItem);
                }
                await _writeFavRepo.UpdateAsync(favList);
            }
            else {
                var newfavList = new WatchList() {
                    UserId = user.Id,
                };
                await _writeFavRepo.AddAsync(newfavList);
                var movieItem = new MovieItem() {
                    MovieId = movieId,
                    WatchListId = newfavList.Id,
                };
                await _writeMovieItemRepo.AddAsync(movieItem);
            }
            return 200;
        }
        return 401;
    }

    public async Task DeleteFromFavourites(string movieId) {
        var movieItem = await _readMovieItemRepo.GetByMovieId(movieId);
        if (movieItem != null) await _writeMovieItemRepo.DeleteAsync(movieItem);
    }

    public async Task<List<GetPersonalMovieDTO>> GetFavouritePersonalMovies(string username) {
        var List = new List<GetPersonalMovieDTO>();
        var user = await _readUserrepo.GetUserByUserName(username);
        if (user != null) {
            var favList = await _readFavRepo.GetWatchListByUserId(user.Id);
            foreach (var movieItem in favList.Movies) {
                var movie = await _readRepo.GetByIdAsync(movieItem.MovieId);
                if (movie.PersonalMovie != null) {
                    List.Add(new GetPersonalMovieDTO() {

                        PublishDate = movie.PersonalMovie.UploadDate.ToString("dd/MM/yy"),
                        Poster = movie.Poster,
                        Description = movie.PersonalMovie.Description,
                        Link = movie.PersonalMovie.MovieLink,
                        PublisherName = username,
                        PublisherPhoto = user.ProfilePhoto,
                        Title = movie.Title,
                        ViewCount = movie.ViewCount,
                        LikeCount = movie.LikeCount,
                        DislikeCount = movie.DislikeCount,
                        Id = movie.PersonalMovie.MovieId,
                    });
                }
            }
        }
        return List;
    }

    public async Task<List<string>> GetFavouriteProfessionalMovies(string username) {

        var List = new List<string>();
        var user = await _readUserrepo.GetUserByUserName(username);
        if (user != null) {

            var favList = await _readFavRepo.GetWatchListByUserId(user.Id);
            foreach (var movieItem in favList.Movies) {

                var movie = await _readRepo.GetByIdAsync(movieItem.MovieId);
                if (movie.ProffesionalMovie != null) {
                    List.Add(movie.Id);
                }
            }
        }
        return List;

    }
}
