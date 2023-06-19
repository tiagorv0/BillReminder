using BillReminder.Domain.Interfaces;

namespace BillReminder.Domain.Params;
public class CategoryParams : IParams
{
    public string CategoryName { get; set; }
}
