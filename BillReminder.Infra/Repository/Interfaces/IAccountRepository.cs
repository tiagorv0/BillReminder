using BillReminder.Domain.DTO;
using BillReminder.Domain.Entities;
using BillReminder.Infra.Repository.Common;

namespace BillReminder.Infra.Repository.Interfaces;
public interface IAccountRepository : IBaseWithDeleteRepository<Account>
{
    Task<PagedResponse<Account>> GetAccountsAsync(Guid userId, Paging page);
}
