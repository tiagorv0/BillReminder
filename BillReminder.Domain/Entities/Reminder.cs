using BillReminder.Domain.Entities.Common;

namespace BillReminder.Domain.Entities;
public class Reminder : EntityBase
{
    public bool IsEnabled { get; set; }
    public int HowManyDaysToRemind { get; set; }
    public int HowManyTimes { get; set; }

    public Guid BillId { get; set; }
    public Bill Bill { get; set; }

    public List<Notification> Notifications { get; set; }
}
