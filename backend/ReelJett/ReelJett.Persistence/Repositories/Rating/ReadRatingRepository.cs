using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class ReadRatingRepository : ReadGenericRepository<Rating>, IReadRatingRepository {

    // Constructor

    public ReadRatingRepository(ReelJettDbContext context) : base(context) {

    }

    // Methods
}
