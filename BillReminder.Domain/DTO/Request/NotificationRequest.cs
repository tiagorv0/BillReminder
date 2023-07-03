namespace BillReminder.Domain.DTO.Request;
public record NotificationRequest(string Subject, string Message, Guid BillId);
