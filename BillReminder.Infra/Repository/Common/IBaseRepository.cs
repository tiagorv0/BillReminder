
using BillReminder.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Query;

namespace BillReminder.Infra.Repository.Common;

public interface IBaseRepository<TEntity> where TEntity : EntityBase
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> GetByIdAsync(Guid id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<bool> ExistAsync(Guid id);
}
