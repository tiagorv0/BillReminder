using BillReminder.Domain.Enums;

namespace BillReminder.Domain.DTO.Response;
public class BillResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public BillStatus Status { get; set; }
    public ReferenceMonth ReferenceMonth { get; set; }
    public DateTime ExpireDate { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
}
