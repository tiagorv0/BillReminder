using BillReminder.Domain.DTO;
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;
using BillReminder.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace BillReminder.Application.Mapper;

[Mapper]
public static partial class CategoryMapper
{
    public static partial Category Map(CategoryRequest request);
    public static partial CategoryResponse Map(Category entity);
    public static partial IEnumerable<CategoryResponse> Map(IEnumerable<Category> list);
    public static partial void Map(CategoryRequest request, Category entity);
    public static partial PagedResponse<CategoryResponse> Map(PagedResponse<Category> list);
}
