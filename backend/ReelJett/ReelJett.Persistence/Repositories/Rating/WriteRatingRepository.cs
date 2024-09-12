using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class WriteRatingRepository : WriteGenericRepository<Rating>, IWriteRatingRepository {

    // Constructor

    public WriteRatingRepository(ReelJettDbContext context) : base(context) {

    }

    // Methods
}
