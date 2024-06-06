namespace BillReminder.Domain.DTO.Response;
public record NotificationResponse(
    Guid Id,
    string Title,
    string Message);
