
using BillReminder.Domain.DTO;
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;
using BillReminder.Domain.Params;

namespace BillReminder.Application.Service.BillService;

public interface IBillService
{
    Task<BillResponse> CreateAsync(BillRequest request);
    Task<BillResponse> UpdateAsync(Guid id, BillRequest request);
    Task<bool> DeleteAsync(Guid id);
    Task<BillResponse> GetByIdAsync(Guid id);
    Task<PagedResponse<BillResponse>> GetBillsAsync(BillParams billParams, Paging page);
    Task CreateBillRecurrencyAsync();
}
