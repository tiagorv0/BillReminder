using BillReminder.Domain.Entities.Common;

namespace BillReminder.Domain.Entities;
public class User : EntityBase
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    public List<Account> Accounts { get; set; }
}
