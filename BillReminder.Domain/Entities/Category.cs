using BillReminder.Domain.Entities.Common;

namespace BillReminder.Domain.Entities;
public class Category : EntityBase
{
    public string Name { get; set; }

    public Guid AccountId { get; set; }
    public Account Account { get; set; }

    public List<Bill> Bills { get; set; }
}
