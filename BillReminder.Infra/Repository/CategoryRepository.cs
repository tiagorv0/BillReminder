using BillReminder.Domain.DTO;
using BillReminder.Domain.Entities;
using BillReminder.Domain.Params;
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

    public async Task<PagedResponse<Category>> GetCategoriesAsync(Guid userId, CategoryParams categoryParams, Paging page)
    {
        var query = _context.Categories.AsNoTracking()
            .Where(c => c.UserId == userId);

        if(!string.IsNullOrWhiteSpace(categoryParams.CategoryName)) 
            query = query.Where(x => x.Name.Contains(categoryParams.CategoryName));

        return await query.GetPagedAsync(page);
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync(Guid userId)
    {
        return await _context.Categories.AsNoTracking()
            .Where(c => c.UserId == userId)
            .Include(x => x.Bills)
            .ToListAsync();
    }
}
