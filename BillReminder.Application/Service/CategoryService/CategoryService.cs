using BillReminder.Application.Mapper;
using BillReminder.Domain.DTO;
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;
using BillReminder.Infra.Repository.Common;
using BillReminder.Infra.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BillReminder.Application.Service.CategoryService;
public class CategoryService : BaseService, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        INotificationCollector notificationCollector,
        ICategoryRepository categoryRepository
    ) : base(unitOfWork, httpContextAccessor, notificationCollector)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryResponse> CreateAsync(CategoryRequest request)
    {
        var entity = CategoryMapper.Map(request);
        entity.UserId = GetLoggedUserId();

        var newCategory = await _categoryRepository.CreateAsync(entity);
        await _unitOfWork.CommitAsync();

        return CategoryMapper.Map(newCategory);
    }

    public async Task<CategoryResponse> UpdateAsync(Guid id, CategoryRequest request)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category is null)
            return default;

        CategoryMapper.Map(request, category);

        var updateCategory = await _categoryRepository.UpdateAsync(category);
        await _unitOfWork.CommitAsync();

        return CategoryMapper.Map(updateCategory);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category is null)
            return false;

        await _categoryRepository.DeleteAsync(category);
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<CategoryResponse> GetByIdAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category is null)
            return default;

        return CategoryMapper.Map(category);
    }

    public async Task<PagedResponse<CategoryResponse>> GetCategoriesAsync(Paging page)
    {
        var userId = GetLoggedUserId();
        var categories = await _categoryRepository.GetCategoriesAsync(userId, page);
        return CategoryMapper.Map(categories);
    }
}
