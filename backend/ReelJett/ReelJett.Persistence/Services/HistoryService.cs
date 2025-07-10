using ReelJett.Application.Services;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Domain.ViewModels;
using RestSharp;

namespace ReelJett.Persistence.Services;

public class HistoryService : IHistoryService {

    // Fields

    private readonly IReadUserRepository _readUserRepository;
    private readonly IReadMovieRepository _readMovieRepository;
    private readonly IWriteMovieRepository _writeMovieRepository;
    private readonly IReadMovieItemRepository _readMovieItemRepository;
    private readonly IWriteMovieItemRepository _writeMovieItemRepository;
    private readonly IReadHistoryListRepository _readHistoryListRepository;
    private readonly IWriteHistoryListRepository _writeHistoryListRepository;
    
    // Constructor

    public HistoryService(
        IWriteHistoryListRepository writeHistoryListRepository,
        IWriteMovieItemRepository writeMovieItemRepository,
        IReadHistoryListRepository readHistoryListRepository,
        IReadMovieItemRepository readMovieItemRepository,
        IWriteMovieRepository writeMovieRepository,
        IReadMovieRepository readMovieRepository,
        IReadUserRepository readUserRepository) {

        _readUserRepository = readUserRepository;
        _readMovieRepository = readMovieRepository;
        _writeMovieRepository = writeMovieRepository;
        _readMovieItemRepository = readMovieItemRepository;
        _writeMovieItemRepository = writeMovieItemRepository;
        _readHistoryListRepository = readHistoryListRepository;
        _writeHistoryListRepository = writeHistoryListRepository;
    }

    public async Task<string> AddMovieToHistoryAsync(string username, string movieId) {

        var historyList = await _readHistoryListRepository.GetByUsername(username);

        if (historyList == null) {
            var user = await _readUserRepository.GetUserByUserName(username);

            if (user == null) return "User not found";

            historyList = new HistoryList {
                UserId = user.Id
            };
            await _writeHistoryListRepository.AddAsync(historyList);
        }

        if (historyList.Movies!.Where(m => m.MovieId == movieId).FirstOrDefault() != null) return "Contains";

        var movieItem = new MovieItem {
            MovieId = movieId,
            HistoryListId = historyList.Id
        };

        await _writeMovieItemRepository.AddAsync(movieItem);
        await _writeHistoryListRepository.UpdateAsync(historyList);
        return "Added";
    }

    public async Task<ICollection<MovieItem>?> GetHistoryMoviesAsync(string username) {

        var originalList=await _readHistoryListRepository.GetMoviesByUsername(username);
        return originalList;
    }
}