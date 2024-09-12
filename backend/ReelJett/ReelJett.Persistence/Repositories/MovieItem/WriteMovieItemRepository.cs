using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class WriteMovieItemRepository : WriteGenericRepository<MovieItem>, IWriteMovieItemRepository {

    // Constructor

    public WriteMovieItemRepository(ReelJettDbContext context) : base(context) { }
}