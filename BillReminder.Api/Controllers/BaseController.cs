using BillReminder.Application.Service;
using BillReminder.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BillReminder.Api.Controllers;

public abstract class BaseController : ControllerBase
{
    private readonly INotificationCollector _notificationCollector;

    protected BaseController(INotificationCollector notificationCollector)
    {
        _notificationCollector = notificationCollector;
    }

    protected IActionResult ApiResponse()
    {
        if (_notificationCollector.HasNotifications())
            return BadRequest(Result<object>.Failure(_notificationCollector.GetNotifications().ToList()));
        else
            return Ok(Result<object>.Success());
    }

    protected IActionResult ApiResponse<T>(T data)
    {
        if (_notificationCollector.HasNotifications())
            return BadRequest(Result<T>.Failure(_notificationCollector.GetNotifications().ToList()));
        else
            return Ok(Result<T>.Success(data));
    }
}
