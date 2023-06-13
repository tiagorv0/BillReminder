using BillReminder.Domain.Entities.Common;

namespace BillReminder.Domain.Entities;
public class Account : EntityBase
{
    public string Name { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public List<Bill> Bills { get; set; }
}
