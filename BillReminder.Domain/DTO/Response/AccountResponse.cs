
namespace BillReminder.Domain.DTO.Response;

public class AccountResponse
{
    public Guid Id { get; set; }
    public DateTime CreateAt { get; set; }
    public string Name { get; set; }
    public IEnumerable<BillResponse> Bills { get; set; }
}
