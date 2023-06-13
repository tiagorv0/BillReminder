namespace BillReminder.Infra.Repository.Common;
public interface IUnitOfWork
{
    Task<bool> CommitAsync();
}
