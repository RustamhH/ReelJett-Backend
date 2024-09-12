using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class WriteMovieRepository : WriteGenericRepository<Movie>, IWriteMovieRepository {

    // Constructor

    public WriteMovieRepository(ReelJettDbContext context) : base(context) { }

    // Methods
}
