using BillReminder.Domain.Enums;

namespace BillReminder.Domain.DTO.Request;
public record BillRequest(
     string Name,
     decimal Value,
     BillStatus Status,
     ReferenceMonth ReferenceMonth,
     DateTime ExpireDate,
     string Comment,
     Guid AccountId,
     Guid CategoryId);
