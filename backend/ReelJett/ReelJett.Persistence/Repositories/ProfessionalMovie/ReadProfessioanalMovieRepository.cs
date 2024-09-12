using Microsoft.EntityFrameworkCore;
using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories.ProfessionalMovie;

public class ReadProfessioanalMovieRepository : ReadGenericRepository<ProffesionalMovie>, IReadProffesionalMovieRepository {

    // Constructor

    public ReadProfessioanalMovieRepository(ReelJettDbContext context) : base(context) {

    }

    // Methods

    public async Task<ProffesionalMovie?> GetByMovieId(string movieId) {
        return await _table.Where(m => m.MovieId == movieId).FirstOrDefaultAsync();
    }
}
