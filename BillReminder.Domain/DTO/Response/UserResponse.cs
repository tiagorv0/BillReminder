namespace BillReminder.Domain.DTO.Response;

public record UserResponse(
    Guid Id,
    DateTime CreatedAt,
    string Name,
    string Email,
    IEnumerable<AccountResponse> Accounts);
