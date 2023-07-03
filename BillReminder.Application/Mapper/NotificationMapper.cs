using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;
using BillReminder.Domain.DTO;
using BillReminder.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace BillReminder.Application.Mapper;
[Mapper]
public static partial class NotificationMapper
{
    public static partial Notification Map(NotificationRequest request);

    public static partial NotificationResponse Map(Notification entity);
    public static partial IEnumerable<NotificationResponse> Map(IEnumerable<Notification> list);
    public static partial void Map(NotificationRequest request, Notification entity);
    public static partial PagedResponse<NotificationResponse> Map(PagedResponse<Notification> list);
}
