namespace BillReminder.Domain.DTO.Response;

public record AccountResponse(Guid Id, DateTime CreatedAt, string Name, IEnumerable<BillResponse> Bills);
