using BillReminder.Domain.Entities.Common;

namespace BillReminder.Infra.Repository.Common;
public interface IBaseWithDeleteRepository<TEntity> : IBaseRepository<TEntity> where TEntity : EntityBase
{
    Task DeleteAsync(TEntity entity);
}
