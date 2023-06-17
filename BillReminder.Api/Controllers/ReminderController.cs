using BillReminder.Application.Service;
using BillReminder.Application.Service.ReminderService;
using BillReminder.Domain.DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillReminder.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ReminderController : BaseController
{
    private readonly IReminderService _reminderService;
    public ReminderController(INotificationCollector notificationCollector, IReminderService reminderService) : base(notificationCollector)
    {
        _reminderService = reminderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
    {
        return ApiResponse(await _reminderService.GetByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(ReminderRequest request)
    {
        return ApiResponse(await _reminderService.CreateAsync(request));
    }

    [HttpPut]
    public async Task<IActionResult> Update(Guid id, ReminderRequest request)
    {
        var result = await _reminderService.UpdateAsync(id, request);
        if (result is null)
            return NotFound();

        return ApiResponse(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _reminderService.DeleteAsync(id);
        if (!result)
            return NotFound();

        return ApiResponse(result);
    }
}
