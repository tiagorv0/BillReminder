using BillReminder.Domain.DTO;
using BillReminder.Domain.Entities;
using BillReminder.Infra.Context;
using BillReminder.Infra.Repository.Common;
using BillReminder.Infra.Repository.Interfaces;
using BillReminder.Infra.Utils;
using Microsoft.EntityFrameworkCore;

namespace BillReminder.Infra.Repository;
public class CategoryRepository : BaseWithDeleteRepository<Category>, ICategoryRepository
{
    public CategoryRepository(BillReminderContext context) : base(context)
    {
    }

    public async Task<PagedResponse<Category>> GetCategoriesAsync(Guid userId, Paging page)
    {
        var query = _context.Categories
            .Where(c => c.UserId == userId)
            .Include(x => x.Bills);

        return await query.GetPagedAsync(page);
    }
}
