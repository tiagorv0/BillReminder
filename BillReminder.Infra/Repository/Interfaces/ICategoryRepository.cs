using BillReminder.Domain.DTO;
using BillReminder.Domain.Entities;
using BillReminder.Domain.Params;
using BillReminder.Infra.Repository.Common;

namespace BillReminder.Infra.Repository.Interfaces;
public interface ICategoryRepository : IBaseWithDeleteRepository<Category>
{
    Task<PagedResponse<Category>> GetCategoriesAsync(Guid accountId, CategoryParams categoryParams, Paging page);
    Task<IEnumerable<Category>> GetCategoriesAsync(Guid accountId);
}
