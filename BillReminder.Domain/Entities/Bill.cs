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

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public Guid AccountId { get; set; }
    public Account Account { get; set; }

    public Guid? ReminderId { get; set; }
    public Reminder Reminder { get; set; }
}
