using BillReminder.Domain.DTO;
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;

namespace BillReminder.Application.Service.CategoryService;
public interface ICategoryService
{
    Task<CategoryResponse> CreateAsync(CategoryRequest request);
    Task<CategoryResponse> UpdateAsync(Guid id, CategoryRequest request);
    Task<bool> DeleteAsync(Guid id);
    Task<CategoryResponse> GetByIdAsync(Guid id);
    Task<PagedResponse<CategoryResponse>> GetCategoriesAsync(Paging page);
}
