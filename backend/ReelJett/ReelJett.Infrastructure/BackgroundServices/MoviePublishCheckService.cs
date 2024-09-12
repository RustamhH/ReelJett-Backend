using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReelJett.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ReelJett.Infrastructure.BackgroundServices;

public class MoviePublishCheckService : BackgroundService {

    // Fields

    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<MoviePublishCheckService> _logger;

    // Constructor

    public MoviePublishCheckService(IServiceScopeFactory serviceScopeFactory, ILogger<MoviePublishCheckService> logger) {

        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    // Methods

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {

        while (!stoppingToken.IsCancellationRequested) {

            await CheckAndUpdateMoviesAsync(stoppingToken);
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }

    private async Task CheckAndUpdateMoviesAsync(CancellationToken cancellationToken) {
        try {
            using (var scope = _serviceScopeFactory.CreateScope()) {

                var personalMovieService = scope.ServiceProvider.GetRequiredService<IPersonalMovieService>();

                await personalMovieService.UpdatePublishedMoviesAsync();

                _logger.LogInformation("Checked and updated published movies successfully.");
            }
        }
        catch (Exception ex) {
            _logger.LogError(ex, "An error occurred while checking and updating movies.");
        }
    }
}