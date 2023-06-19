using BillReminder.Application.Service;
using BillReminder.Application.Service.CategoryService;
using BillReminder.Domain.DTO;
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillReminder.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoryController : BaseController
{
    private readonly ICategoryService _categoryService;

    public CategoryController(INotificationCollector notificationCollector, ICategoryService categoryService) : base(notificationCollector)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CategoryParams categoryParams, [FromQuery] Paging page)
    {
        return ApiResponse(await _categoryService.GetCategoriesAsync(categoryParams, page));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await _categoryService.GetByIdAsync(id);
        if (result is null)
            return NotFound();

        return ApiResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CategoryRequest request)
    {
        return ApiResponse(await _categoryService.CreateAsync(request));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] CategoryRequest request)
    {
        var result = await _categoryService.UpdateAsync(id, request);
        if (result is null)
            return NotFound();

        return ApiResponse(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await _categoryService.DeleteAsync(id);
        if (!result)
            return NotFound();

        return ApiResponse(result);
    }

    [HttpGet("Dados-por-categoria")]
    public async Task<IActionResult> GetInfoPerCategory()
    {
        return ApiResponse(await _categoryService.GetInfoPerCategoryAsync());
    }
}
