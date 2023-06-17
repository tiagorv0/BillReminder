
namespace BillReminder.Domain.DTO.Response;

public record ReminderResponse(Guid Id, DateTime CreatedAt, bool IsEnabled, int HowManyDaysToRemind, int HowManyTimes);
