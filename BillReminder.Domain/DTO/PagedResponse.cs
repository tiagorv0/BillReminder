namespace BillReminder.Domain.DTO;

public record PagedResponse<T>(IEnumerable<T> Result, int CurrentPage, int Page, int TotalItems);
