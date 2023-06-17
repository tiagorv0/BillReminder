
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;
using BillReminder.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace BillReminder.Application.Mapper;

[Mapper]
public static partial class ReminderMapper
{
    public static partial Reminder Map(ReminderRequest request);
    public static partial ReminderResponse Map(Reminder entity);
    public static partial IEnumerable<ReminderResponse> Map(IEnumerable<Reminder> list);
    public static partial void Map(ReminderRequest request, Reminder entity);
}
