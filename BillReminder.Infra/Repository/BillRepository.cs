using BillReminder.Domain.DTO;
using BillReminder.Domain.Entities;
using BillReminder.Domain.Params;
using BillReminder.Infra.Context;
using BillReminder.Infra.Repository.Common;
using BillReminder.Infra.Repository.Interfaces;
using BillReminder.Infra.Utils;
using Microsoft.EntityFrameworkCore;

namespace BillReminder.Infra.Repository;
public class BillRepository : BaseWithDeleteRepository<Bill>, IBillRepository
{
    public BillRepository(BillReminderContext context) : base(context)
    {
    }

    public async Task<PagedResponse<Bill>> GetBillsAsync(Guid userId, BillParams billParams, Paging page)
    {
        var query = _context.Bills.AsNoTracking()
            .Include(x => x.Category)
            .Where(x => x.Category.UserId.Equals(userId));

        if(!string.IsNullOrWhiteSpace(billParams.Name))
            query = query.Where(x => x.Name.Contains(billParams.Name));

        if(billParams.Value.HasValue)
            query = query.Where(x => x.Value ==  billParams.Value.Value);

        if(billParams.Status is not null)
            query = query.Where(x => billParams.Status.Contains(x.Status));

        if (billParams.ReferenceMonth is not null)
            query = query.Where(x => billParams.ReferenceMonth.Contains(x.ReferenceMonth));

        if (billParams.CreatedAt.HasValue)
            query = query.Where(x => x.CreatedAt.Date == billParams.CreatedAt.Value);

        if (billParams.ExpireDate.HasValue)
            query = query.Where(x => x.ExpireDate.Date == billParams.ExpireDate.Value);

        if (!string.IsNullOrWhiteSpace(billParams.CategoryName))
            query = query.Where(x => x.Category.Name.Contains(billParams.CategoryName));

        return await query.GetPagedAsync(page);
    }
}
