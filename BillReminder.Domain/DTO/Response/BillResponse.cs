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
    bool Reminder,
    bool Recurrency,
    DateTime CreatedAt,
    Guid CategoryId,
    string CategoryName);
