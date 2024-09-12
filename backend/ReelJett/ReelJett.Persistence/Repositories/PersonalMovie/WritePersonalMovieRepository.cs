using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class WritePersonalMovieRepository : WriteGenericRepository<PersonalMovie>, IWritePersonalMovieRepository {

    // Constructor

    public WritePersonalMovieRepository(ReelJettDbContext context) : base(context) { }

    // Methods
}
