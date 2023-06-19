using BillReminder.Domain.DTO;
using BillReminder.Domain.Entities;
using BillReminder.Infra.Context;
using BillReminder.Infra.Repository.Common;
using BillReminder.Infra.Repository.Interfaces;
using BillReminder.Infra.Utils;
using Microsoft.EntityFrameworkCore;

namespace BillReminder.Infra.Repository;
public class AccountRepository : BaseWithDeleteRepository<Account>, IAccountRepository
{
    public AccountRepository(BillReminderContext context) : base(context)
    {
    }

    public async Task<PagedResponse<Account>> GetAccountsAsync(Guid userId, Paging page)
    {
        var query = _context.Accounts.AsNoTracking()
            .Where(x => x.UserId == userId);

        return await query.GetPagedAsync(page);
    }
}
