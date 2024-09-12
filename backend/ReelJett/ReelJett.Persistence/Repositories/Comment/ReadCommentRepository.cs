using ReelJett.Persistence.DbContexts;
using ReelJett.Application.Repositories;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Repositories.Common;

namespace ReelJett.Persistence.Repositories;

public class ReadCommentRepository : ReadGenericRepository<Comment>, IReadCommentRepository {

    // Constructor

    public ReadCommentRepository(ReelJettDbContext context) : base(context) { }

    // Methods
}
