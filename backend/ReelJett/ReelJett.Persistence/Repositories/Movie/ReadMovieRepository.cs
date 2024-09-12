using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class ReadMovieRepository : ReadGenericRepository<Movie>, IReadMovieRepository {

    // Constructor

    public ReadMovieRepository(ReelJettDbContext context) : base(context) { }

    // Methods
}
