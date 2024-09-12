using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ReelJett.Persistence.DbContexts;
using ReelJett.Domain.Entities.Abstracts;
using ReelJett.Application.Repositories.Common;

namespace ReelJett.Persistence.Repositories.Common;

public class ReadGenericRepository<T> : GenericRepository<T>, IReadGenericRepository<T> where T : class, IBaseEntity, new() {

    // Constructor

    public ReadGenericRepository(ReelJettDbContext context) : base(context) { }

    // Methods

    public async Task<IEnumerable<T>?> GetAllAsync() {
        return _table.Where(x => x.IsDeleted == false);
    }

    public async Task<IQueryable<T>?> GetByExpressionAsync(Expression<Func<T, bool>> expression) {
        return _table.Where(expression);
    }

    public async Task<T?> GetByIdAsync(string id) {
        return await _table.FirstOrDefaultAsync(x => x.Id == id);
    }
}