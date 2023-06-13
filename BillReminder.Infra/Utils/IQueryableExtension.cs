using BillReminder.Domain.DTO;
using BillReminder.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace BillReminder.Infra.Utils;
public static class IQueryableExtension
{
    public static async Task<PagedResponse<T>> GetPagedAsync<T>(this IQueryable<T> query, Paging page) where T : EntityBase
    {
        query = query.OrderByDescending(x => x.CreatedAt);

        var totalItems = await query.CountAsync();

        var pageCount = Math.Ceiling(totalItems / page.ResultPerPage);

        var data = await query
                           .Skip((page.Page - 1) * (int)page.ResultPerPage)
                           .Take((int)page.ResultPerPage)
                           .ToListAsync();

        return new PagedResponse<T>(data, page.Page, (int)pageCount, totalItems);
    }
}
