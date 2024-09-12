using ReelJett.Domain.Entities.Abstracts;

namespace ReelJett.Application.Repositories.Common;

public interface IWriteGenericRepository<T> : IGenericRepository<T> where T : class, IBaseEntity, new() {

    // Methods

    Task SaveChangeAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task DeleteAsync(string id);
    Task AddRangeAsync(IEnumerable<T> entities);
}