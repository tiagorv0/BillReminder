using BillReminder.Domain.Entities;
using BillReminder.Infra.Context;
using BillReminder.Infra.Repository.Common;
using BillReminder.Infra.Repository.Interfaces;

namespace BillReminder.Infra.Repository;
public class ReminderRepository : BaseWithDeleteRepository<Reminder>, IReminderRepository
{
    public ReminderRepository(BillReminderContext context) : base(context)
    {
    }
}
