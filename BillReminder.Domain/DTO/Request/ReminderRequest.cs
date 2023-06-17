
namespace BillReminder.Domain.DTO.Request;

public record ReminderRequest(bool IsEnabled, int HowManyDaysToRemind, int HowManyTimes, Guid BillId);
