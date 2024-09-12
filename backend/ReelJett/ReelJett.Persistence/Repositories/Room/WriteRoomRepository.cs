using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class WriteRoomRepository : WriteGenericRepository<Room>, IWriteRoomRepository {

    // Constructor

    public WriteRoomRepository(ReelJettDbContext context) : base(context) {

    }

    // Methods
}
