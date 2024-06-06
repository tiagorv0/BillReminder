using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;

namespace BillReminder.Application.Service.NotificationService;
public interface INotificationService
{
    Task<NotificationResponse> CreateNotificationAsync(NotificationRequest request);
    Task BillIsDueTodayNotificationAsync();
    Task BillIsDueNotificationAsync();
    Task BillWasDueNotificationAsync();
}
