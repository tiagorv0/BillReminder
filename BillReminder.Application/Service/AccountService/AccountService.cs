
using BillReminder.Application.Mapper;
using BillReminder.Domain.DTO;
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;
using BillReminder.Infra.Repository.Common;
using BillReminder.Infra.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BillReminder.Application.Service.AccountService;

public class AccountService : BaseService, IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        INotificationCollector notificationCollector,
        IAccountRepository accountRepository) : base(unitOfWork, httpContextAccessor, notificationCollector)
    {
        _accountRepository = accountRepository;
    }

    public async Task<AccountResponse> CreateAsync(AccountRequest request)
    {
        var entity = AccountMapper.Map(request);
        entity.UserId = GetLoggedUserId();

        var newAccount = await _accountRepository.CreateAsync(entity);
        await _unitOfWork.CommitAsync();

        return AccountMapper.Map(newAccount);
    }

    public async Task<AccountResponse> UpdateAsync(Guid id, AccountRequest request)
    {
        var account = await _accountRepository.GetByIdAsync(id);
        if (account is null)
            return default;
        AccountMapper.Map(request, account);

        var updateAccount = await _accountRepository.UpdateAsync(account);
        await _unitOfWork.CommitAsync();

        return AccountMapper.Map(updateAccount);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var account = await _accountRepository.GetByIdAsync(id);
        if (account is null)
            return false;

        await _accountRepository.DeleteAsync(account);
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<AccountResponse> GetByIdAsync(Guid id)
    {
        var account = await _accountRepository.GetByIdAsync(id);
        if (account is null)
            return default;

        return AccountMapper.Map(account);
    }

    public async Task<PagedResponse<AccountResponse>> GetAccountsAsync(Paging page)
    {
        var userId = GetLoggedUserId();
        var accounts = await _accountRepository.GetAccountsAsync(userId, page);
        return AccountMapper.Map(accounts);
    }
}
