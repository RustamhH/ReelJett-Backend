using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories.ProfessionalMovie;

public class WriteProffesionalMovieRepository : WriteGenericRepository<ProffesionalMovie>, IWriteProffesionalMovieRepository {

    // Constructor

    public WriteProffesionalMovieRepository(ReelJettDbContext context) : base(context) {

    }

    // Methods
}