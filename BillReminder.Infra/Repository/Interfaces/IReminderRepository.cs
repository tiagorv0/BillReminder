using BillReminder.Domain.Entities;
using BillReminder.Infra.Repository.Common;

namespace BillReminder.Infra.Repository.Interfaces;
public interface IReminderRepository : IBaseRepository<Reminder>
{
}
