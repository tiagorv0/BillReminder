using BillReminder.Domain.Entities.Common;
using BillReminder.Domain.Enums;

namespace BillReminder.Domain.Entities;
public class Bill : EntityBase
{
    public string Name { get; set; }
    public decimal Value { get; set; }
    public BillStatus Status { get; set; }
    public ReferenceMonth ReferenceMonth { get; set; }
    public DateTime ExpireDate { get; set; }
    public string Comment { get; set; }
    public bool IsPaid { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public Guid AccountId { get; set; }
    public Account Account { get; set; }

    public bool Reminder { get; set; }
    public bool Recurrency { get; set; }

    public List<Notification> Notifications { get; set; }
}
