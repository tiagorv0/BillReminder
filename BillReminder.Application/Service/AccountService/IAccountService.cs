
using BillReminder.Domain.DTO;
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;

namespace BillReminder.Application.Service.AccountService;

public interface IAccountService
{
    Task<AccountResponse> CreateAsync(AccountRequest request);
    Task<AccountResponse> UpdateAsync(Guid id, AccountRequest request);
    Task<bool> DeleteAsync(Guid id);
    Task<AccountResponse> GetByIdAsync(Guid id);
    Task<PagedResponse<AccountResponse>> GetAccountsAsync(Paging page);
}
