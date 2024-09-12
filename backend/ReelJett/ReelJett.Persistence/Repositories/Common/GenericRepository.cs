using Microsoft.EntityFrameworkCore;
using ReelJett.Persistence.DbContexts;
using ReelJett.Domain.Entities.Abstracts;
using ReelJett.Application.Repositories.Common;

namespace ReelJett.Persistence.Repositories.Common;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity, new() {

    // Fields

    protected DbSet<T> _table;
    protected readonly ReelJettDbContext _context;

    // Constrctor

    public GenericRepository(ReelJettDbContext context) {
        _context = context;
        _table = _context.Set<T>();
    }
}
