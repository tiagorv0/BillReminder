using BillReminder.Domain.DTO;
using BillReminder.Domain.Entities;
using BillReminder.Infra.Repository.Common;

namespace BillReminder.Infra.Repository.Interfaces;
public interface ICategoryRepository : IBaseWithDeleteRepository<Category>
{
    Task<PagedResponse<Category>> GetCategoriesAsync(Guid userId, Paging page);
}
