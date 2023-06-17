
using BillReminder.Domain.Enums;
using BillReminder.Domain.Interfaces;

namespace BillReminder.Domain.Params;

public class BillParams : IParams
{
    public string Name { get; set; }
    public decimal? Value { get; set; }
    public BillStatus?[] Status { get; set; }
    public ReferenceMonth?[] ReferenceMonth { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? ExpireDate { get; set; }
    public string CategoryName { get; set; }
}
