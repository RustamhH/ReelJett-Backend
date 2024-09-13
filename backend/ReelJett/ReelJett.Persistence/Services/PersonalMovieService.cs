using ReelJett.Domain.DTO;
using System.Globalization;
using ReelJett.Application.Services;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Domain.Helpers;
using System.Xml.Linq;
namespace ReelJett.Persistence.Services;

public class PersonalMovieService : IPersonalMovieService {

    // Fields

    private readonly IReadMovieRepository _readRepo;
    private readonly IWriteMovieRepository _writeRepo;
    private readonly IReadUserRepository _readUserrepo;
    private readonly IReadPersonalMovieRepository _readPersonalrepo;
    private readonly IWritePersonalMovieRepository _writePersonalrepo;
    
    // Constructor

    public PersonalMovieService(IReadPersonalMovieRepository readPersonalrepo,
        IWritePersonalMovieRepository writePersonalrepo,
        IReadMovieRepository readRepo,
        IWriteMovieRepository writerepo,
        IReadUserRepository readUserrepo) {

        _readRepo = readRepo;
        _writeRepo = writerepo;
        _readPersonalrepo = readPersonalrepo;
        _writePersonalrepo = writePersonalrepo;
        _readUserrepo = readUserrepo;
        
    }

    // Methods

    public async Task<string> AddPersonalMovieAsync(AddPersonalMovieDTO entity, string username) {

        if (entity.Title == "" || entity.Poster == null || entity.Date == "" || entity.Description == "" || entity.Link == "") return "Fill all the form values";
        var user = (await _readUserrepo.GetUserByUserName(username));
        if (user == null) return $"User Not Found";

        DateTime dateTime = DateTime.Parse(entity.Date, null, DateTimeStyles.RoundtripKind);
        DateTime dateTime1 = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0);
        if (dateTime1 < DateTime.UtcNow) return "Invalid Date";

        var userId = user.Id;
        var movie = new Movie();
        movie.Title = entity.Title;
        var poster = await BlobHandler.UploadToBlobStorage(entity.Poster);
        movie.Poster = poster;
        await _writeRepo.AddAsync(movie);

        var personalMovie = new PersonalMovie() {
            MovieLink = entity.Link,
            Description = entity.Description,
            UploadDate = dateTime,
            MovieId = movie.Id,
            UserId = userId
        };

        await _writePersonalrepo.AddAsync(personalMovie);
        return "";
    }

    public async Task DeletePersonalMovieAsync(string movieId) {

        var movie = await _readRepo.GetByIdAsync(movieId);
        if (movie != null) await _writeRepo.DeleteAsync(movie);
    }

    public async Task<List<GetPersonalMovieDTO>> GetPersonalMoviesAsync() {

        var movies = (await _readPersonalrepo.GetAllAsync()).ToList();
        var dto = new List<GetPersonalMovieDTO>();

        foreach (var item in movies) {
            if (item.IsPublished) {
                var Publisher = await _readUserrepo.GetByIdAsync(item.UserId);
                var Movie = await _readRepo.GetByIdAsync(item.MovieId);
                dto.Add(new GetPersonalMovieDTO() {
                    PublishDate = item.UploadDate.ToString("dd/MM/yy"),
                    Poster = Movie.Poster,
                    Description = item.Description,
                    Link = item.MovieLink,
                    PublisherName = Publisher.UserName,
                    PublisherPhoto = Publisher.ProfilePhoto,
                    Title = Movie.Title,
                    ViewCount = Movie.ViewCount,
                    LikeCount = Movie.LikeCount,
                    DislikeCount = Movie.DislikeCount,
                    Id = item.MovieId,
                });
            }

        }

        return dto;
    }

    public async Task<List<GetMyMoviesDTO>> GetPersonalMoviesByUsername(string username) {


        var movies = (await _readPersonalrepo.GetAllAsync()).ToList();
        var dto = new List<GetMyMoviesDTO>();

        foreach (var item in movies) {
            var Publisher = await _readUserrepo.GetByIdAsync(item.UserId);
            var Movie = await _readRepo.GetByIdAsync(item.MovieId);
            if(Publisher!=null && Movie!=null)
            {
                if(username==Publisher.UserName)
                {
                    dto.Add(new GetMyMoviesDTO()
                    {
                        Id = Movie.Id,
                        Poster = Movie.Poster,
                        Title = Movie.Title,
                        Description = item.Description,
                        Link = item.MovieLink,
                        PublishDate = item.UploadDate.ToString("dd/MM/yy"),
                        PublishState = item.IsPublished ? "Public" : "Draft",
                        ViewCount = Movie.ViewCount,
                        LikeCount = Movie.LikeCount,
                        DislikeCount = Movie.DislikeCount,
                        CommentCount = Movie.Comments != null ? Movie.Comments.Count : 0
                    });
                }
                
            }
        }

        return dto;
    }

    public async Task<List<UserOperationDTO>> GetUserCommentsAsync(string movieId)
    {
        var movie = await _readRepo.GetByIdAsync(movieId);
        var list = new List<UserOperationDTO>();
        if (movie != null)
        {
            foreach (var comment in movie.Comments)
            {
                list.Add(new UserOperationDTO()
                {
                    Id= comment.Id,
                    OperationTime = comment.CreatedAt.ToString("dd/MM/yy HH:mm"),
                    ProfilePhoto = comment.User.ProfilePhoto,
                    Username = comment.User.UserName,
                    Content ="-"+ comment.Content,
                });
            }
        }
        return list;
    }

    public async Task<List<UserOperationDTO>> GetUserDislikesAsync(string movieId)
    {
        var movie = await _readRepo.GetByIdAsync(movieId);
        var list=new List<UserOperationDTO>();
        if (movie != null)
        {
            foreach (var like in movie.UserLikes)
            {
                if(!like.IsLike)
                {
                    list.Add(new UserOperationDTO()
                    {
                        Id=like.Id,
                        OperationTime = like.LastModifiedAt.ToString("dd/MM/yy HH:mm"),
                        ProfilePhoto=like.User.ProfilePhoto,
                        Username=like.User.UserName
                    });
                }
                
            }
        }
        return list;
    }

    public async Task<List<UserOperationDTO>> GetUserLikesAsync(string movieId)
    {
        var movie = await _readRepo.GetByIdAsync(movieId);
        var list = new List<UserOperationDTO>();
        if (movie != null)
        {
            foreach (var like in movie.UserLikes)
            {
                if (like.IsLike)
                {
                    list.Add(new UserOperationDTO()
                    {
                        Id=like.Id,
                        OperationTime = like.LastModifiedAt.ToString("dd/MM/yy HH:mm"),
                        ProfilePhoto = like.User.ProfilePhoto,
                        Username = like.User.UserName
                    });
                }

            }
        }
        return list;
    }

    public async Task<List<UserOperationDTO>> GetUserViewsAsync(string movieId)
    {
        var movie = await _readRepo.GetByIdAsync(movieId);
        var list = new List<UserOperationDTO>();
        if (movie != null)
        {
            foreach (var view in movie.UserViews)
            {
                list.Add(new UserOperationDTO()
                {
                    Id=view.Id,
                    OperationTime = view.CreatedAt.ToString("dd/MM/yy HH:mm"),
                    ProfilePhoto = view.User.ProfilePhoto,
                    Username = view.User.UserName
                });
            }
        }
        return list;
    }

    public async Task UpdatePublishedMoviesAsync() {

        var movies = _readPersonalrepo.GetAllAsync();
        foreach (var movie in movies.Result.ToList()) {

            DateTime dateTimeNow = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, DateTime.UtcNow.Hour, DateTime.UtcNow.Minute, 0);
            if ((movie.IsPublished == false) && (movie.UploadDate <= dateTimeNow)) {

                movie.IsPublished = true;
                await _writePersonalrepo.UpdateAsync(movie);
            }
        }
    }

    
}