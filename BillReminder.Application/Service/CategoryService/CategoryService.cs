﻿using BillReminder.Application.Mapper;
using BillReminder.Domain.DTO;
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;
using BillReminder.Domain.Params;
using BillReminder.Infra.Repository.Common;
using BillReminder.Infra.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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
        var category = await _categoryRepository.GetByIdAsync(id, x => x.Include(c => c.Bills));
        if (category is null)
            return default;

        return CategoryMapper.Map(category);
    }

    public async Task<PagedResponse<CategoryResponse>> GetCategoriesAsync(CategoryParams categoryParams, Paging page)
    {
        var userId = GetLoggedUserId();
        var categories = await _categoryRepository.GetCategoriesAsync(userId, categoryParams, page);
        return CategoryMapper.Map(categories);
    }

    public async Task<IEnumerable<InfoPerCategoryDTO>> GetInfoPerCategoryAsync(Guid accountId)
    { 
        var categories = await _categoryRepository.GetCategoriesAsync(accountId);
        return categories.Select(x => new InfoPerCategoryDTO(x.Id, x.Name, x.Bills.Count, x.Bills.Sum(b => b.Value)));
    }
}
