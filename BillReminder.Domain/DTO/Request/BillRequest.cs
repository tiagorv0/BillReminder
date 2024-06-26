﻿namespace BillReminder.Domain.DTO.Request;
public record BillRequest(
     string Name,
     decimal Value,
     int Status,
     int ReferenceMonth,
     DateTime ExpireDate,
     bool IsPaid,
     string Comment,
     bool Reminder,
     Guid AccountId,
     Guid CategoryId);
