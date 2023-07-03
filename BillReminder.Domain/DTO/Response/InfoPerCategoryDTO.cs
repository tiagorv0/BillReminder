namespace BillReminder.Domain.DTO.Response
{
    public record InfoPerCategoryDTO(Guid CategoryId, string CategoryName, int Quantity, decimal TotalValue);
}
