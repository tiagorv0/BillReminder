using BillReminder.Domain.Entities;
using BillReminder.Infra.Context;
using BillReminder.Infra.Repository.Common;
using BillReminder.Infra.Repository.Interfaces;

namespace BillReminder.Infra.Repository;
public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
{
    public NotificationRepository(BillReminderContext context) : base(context)
    {
    }
}
