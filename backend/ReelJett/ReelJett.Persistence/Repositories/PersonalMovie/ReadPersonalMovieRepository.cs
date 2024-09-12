using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class ReadPersonalMovieRepository : ReadGenericRepository<PersonalMovie>, IReadPersonalMovieRepository {

    // Constructor

    public ReadPersonalMovieRepository(ReelJettDbContext context) : base(context) { }

    // Methods
}
