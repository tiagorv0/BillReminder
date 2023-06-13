namespace BillReminder.Domain.DTO.Response;
public class CategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<BillResponse> Bills { get; set; }
}
