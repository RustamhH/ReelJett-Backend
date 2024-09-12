using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class ReadRoomRepository : ReadGenericRepository<Room>, IReadRoomRepository {

    // Constructor

    public ReadRoomRepository(ReelJettDbContext context) : base(context) {

    }

    // Methods
}
