using BillReminder.Application.Service;
using BillReminder.Application.Service.AccountService;
using BillReminder.Domain.DTO;
using BillReminder.Domain.DTO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillReminder.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AccountController : BaseController
{
    private readonly IAccountService _accountService;
    public AccountController(INotificationCollector notificationCollector, IAccountService accountService) : base(notificationCollector)
    {
        _accountService = accountService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(AccountRequest request)
    {
        return ApiResponse(await _accountService.CreateAsync(request));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, AccountRequest request)
    {
        var result = await _accountService.UpdateAsync(id, request);
        if (result is null)
            NotFound();

        return ApiResponse(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _accountService.DeleteAsync(id);
        if (!result)
            NotFound();

        return ApiResponse(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _accountService.GetByIdAsync(id);
        if (result is null)
            NotFound();

        return ApiResponse(result);
    }

    [HttpGet("get-accounts")]
    public async Task<IActionResult> GetAccounts(Paging page)
    {
        return ApiResponse(await _accountService.GetAccountsAsync(page));
    }
}
