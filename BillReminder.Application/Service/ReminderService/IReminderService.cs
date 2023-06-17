
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;

namespace BillReminder.Application.Service.ReminderService;

public interface IReminderService
{
    Task<ReminderResponse> CreateAsync(ReminderRequest request);
    Task<ReminderResponse> UpdateAsync(Guid id, ReminderRequest request);
    Task<bool> DeleteAsync(Guid id);
    Task<ReminderResponse> GetByIdAsync(Guid id);
}
