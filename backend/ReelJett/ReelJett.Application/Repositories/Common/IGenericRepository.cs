using ReelJett.Domain.Entities.Abstracts;

namespace ReelJett.Application.Repositories.Common;

public interface IGenericRepository<T> where T : class, IBaseEntity, new(){

}