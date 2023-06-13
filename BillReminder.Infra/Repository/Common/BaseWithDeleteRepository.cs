using BillReminder.Domain.Entities.Common;
using BillReminder.Infra.Context;

namespace BillReminder.Infra.Repository.Common;
public class BaseWithDeleteRepository<TEntity> : BaseRepository<TEntity>, IBaseWithDeleteRepository<TEntity> where TEntity : EntityBase
{
    public BaseWithDeleteRepository(BillReminderContext context) : base(context)
    {
    }

    public virtual Task DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }
}
