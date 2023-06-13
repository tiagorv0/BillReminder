using BillReminder.Infra.Context;

namespace BillReminder.Infra.Repository.Common;
public class UnitOfWork : IUnitOfWork
{
    public BillReminderContext _context;

    public UnitOfWork(BillReminderContext context)
    {
        _context = context;
    }

    public async Task<bool> CommitAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
