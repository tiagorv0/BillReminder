
using BillReminder.Domain.Entities;

namespace BillReminder.Domain.DTO.Response;

public class UserResponse
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public IEnumerable<Account> Accounts { get; set; }
}
