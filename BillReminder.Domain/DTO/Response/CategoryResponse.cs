namespace BillReminder.Domain.DTO.Response;
public record CategoryResponse(
    Guid Id,
    DateTime CreatedAt,
    string Name,
    IEnumerable<BillResponse> Bills);
