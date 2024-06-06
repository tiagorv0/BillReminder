namespace BillReminder.Domain.DTO.Request;
public record NotificationRequest(string Title, string Message, Guid BillId);
