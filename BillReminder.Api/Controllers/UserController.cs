using BillReminder.Application.Service;
using BillReminder.Application.Service.UserService;
using BillReminder.Domain.DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillReminder.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(INotificationCollector notificationCollector, IUserService userService) : base(notificationCollector)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOwnUser()
    {
        return ApiResponse(await _userService.GetOwnUserAsync());
    }

    [HttpPost("Registro")]
    [AllowAnonymous]
    public async Task<IActionResult> Registro([FromBody] UserRequest request)
    {
        return ApiResponse(await _userService.CreateAsync(request));
    }

    [HttpPut("Atualizar")]
    public async Task<IActionResult> Atualizar(Guid id, [FromBody] UserRequest request)
    {
        var result = await _userService.UpdateAsync(id, request);
        if (result is null)
            return NotFound();

        return ApiResponse(result);
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        return ApiResponse(await _userService.HandleLoginAsync(request));
    }
}
