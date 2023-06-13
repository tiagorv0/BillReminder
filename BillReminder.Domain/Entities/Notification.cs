using BillReminder.Domain.Entities.Common;

namespace BillReminder.Domain.Entities;
public class Notification : EntityBase
{
    public string Subject { get; set; }
    public string Message { get; set; }

    public Guid ReminderId { get; set; }
    public Reminder Reminder { get; set; }
}
