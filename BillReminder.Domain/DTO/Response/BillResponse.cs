using BillReminder.Domain.Enums;

namespace BillReminder.Domain.DTO.Response;
public record BillResponse(
    Guid Id,
    string Name,
    decimal Value,
    BillStatus Status,
    ReferenceMonth ReferenceMonth,
    DateTime ExpireDate,
    string Comment,
    DateTime CreatedAt,
    string CategoryName);
