using Microsoft.EntityFrameworkCore;
using ReelJett.Application.Services;
using ReelJett.Persistence.Services;
using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReelJett.Persistence.Repositories.CommentLikes;
using ReelJett.Persistence.Repositories.ProfessionalMovie;

namespace ReelJett.Persistence;

public static class RegisterServices {

    public static void AddPersistenceRegister(this IServiceCollection services) {

        // Services

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IHistoryService, HistoryService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IBaseMovieService, BaseMovieService>();
        services.AddScoped<IFavouriteService, FavouriteService>();
        services.AddScoped<IPersonalMovieService, PersonalMovieService>();

        // Context

        services.AddDbContext<ReelJettDbContext>(options => {
            ConfigurationBuilder configurationBuilder = new();
            var builder = configurationBuilder.AddJsonFile("appsettings.json").Build();

            options.UseLazyLoadingProxies()
                   .UseSqlServer(builder.GetConnectionString("AzureFree"));
                   //.UseSqlServer(builder.GetConnectionString("Default"));
        });

        // Register all Repository in Persistence

        // All Read Repository
        services.AddScoped<IReadUserRepository, ReadUserRepository>();
        services.AddScoped<IReadMovieRepository, ReadMovieRepository>();
        services.AddScoped<IReadCommentRepository, ReadCommentRepository>();
        services.AddScoped<IReadMovieItemRepository, ReadMovieItemRepository>();
        services.AddScoped<IReadUserTokenRepository, ReadUserTokenRepository>();
        services.AddScoped<IReadUserLikesRepository, ReadUserLikesRepository>();
        services.AddScoped<IReadUserViewsRepository, ReadUserViewsRepository>();
        services.AddScoped<IReadWatchListRepository, ReadWatchListRepository>();
        services.AddScoped<IReadHistoryListRepository, ReadHistoryListRepository>();
        services.AddScoped<IReadCommentLikesRepository, ReadCommentLikesRepository>();
        services.AddScoped<IReadPersonalMovieRepository, ReadPersonalMovieRepository>();
        services.AddScoped<IReadProffesionalMovieRepository, ReadProfessioanalMovieRepository>();

        // All Write Repository
        services.AddScoped<IWriteUserRepository, WriteUserRepository>();
        services.AddScoped<IWriteMovieRepository, WriteMovieRepository>();
        services.AddScoped<IWriteCommentRepository, WriteCommentRepository>();
        services.AddScoped<IWriteMovieItemRepository, WriteMovieItemRepository>();
        services.AddScoped<IWriteUserTokenRepository, WriteUserTokenRepository>();
        services.AddScoped<IWriteUserLikesRepository, WriteUserLikesRepository>();
        services.AddScoped<IWriteUserViewsRepository, WriteUserViewsRepository>();
        services.AddScoped<IWriteWatchListRepository, WriteWatchListRepository>();
        services.AddScoped<IWriteHistoryListRepository, WriteHistoryListRepository>();
        services.AddScoped<IWriteCommentLikesRepository, WriteCommentLikesRepository>();
        services.AddScoped<IWritePersonalMovieRepository, WritePersonalMovieRepository>();
        services.AddScoped<IWriteProffesionalMovieRepository, WriteProffesionalMovieRepository>();

    }
}
