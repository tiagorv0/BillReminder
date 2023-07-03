namespace BillReminder.Domain.DTO.Response;
public record NotificationResponse(
    Guid Id,
    string Subject,
    string Message);
