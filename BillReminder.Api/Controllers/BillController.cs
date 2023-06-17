using BillReminder.Application.Service;
using BillReminder.Application.Service.BillService;
using BillReminder.Domain.DTO;
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BillReminder.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BillController : BaseController
{
    private readonly IBillService _billService;
    public BillController(INotificationCollector notificationCollector, IBillService billService) : base(notificationCollector)
    {
        _billService = billService;
    }

    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
    {
        return ApiResponse(await _billService.GetByIdAsync(id));
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllBills(BillParams billParams, Paging page)
    {
        return ApiResponse(await _billService.GetBillsAsync(billParams, page));
    }

    [HttpPost]
    public async Task<IActionResult> Create(BillRequest request)
    {
        return ApiResponse(await _billService.CreateAsync(request));
    }

    [HttpPut]
    public async Task<IActionResult> Update(Guid id, BillRequest request)
    {
        var result = await _billService.UpdateAsync(id, request);
        if (result is null)
            return NotFound();

        return ApiResponse(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _billService.DeleteAsync(id);
        if (!result)
            return NotFound();

        return ApiResponse(result);
    }
}
