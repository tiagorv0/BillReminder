using BillReminder.Domain.Entities.Common;

namespace BillReminder.Domain.Entities;
public class Notification : EntityBase
{
    public string Subject { get; set; }
    public string Message { get; set; }

    public Guid BillId { get; set; }
    public Bill Bill { get; set; }
}
