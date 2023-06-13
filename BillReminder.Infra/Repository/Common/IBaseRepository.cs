
using BillReminder.Domain.Entities.Common;

namespace BillReminder.Infra.Repository.Common;

public interface IBaseRepository<TEntity> where TEntity : EntityBase
{
    Task<TEntity> CreateAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
}
