
using BillReminder.Domain.DTO;
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;
using BillReminder.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace BillReminder.Application.Mapper;

[Mapper]
public static partial class AccountMapper
{
    public static partial Account Map(AccountRequest request);
    public static partial AccountResponse Map(Account entity);
    public static partial IEnumerable<AccountResponse> Map(IEnumerable<Account> list);
    public static partial void Map(AccountRequest request, Account entity);
    public static partial PagedResponse<AccountResponse> Map(PagedResponse<Account> list);
}
