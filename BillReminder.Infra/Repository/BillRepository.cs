using BillReminder.Domain.Entities;
using BillReminder.Infra.Context;
using BillReminder.Infra.Repository.Common;
using BillReminder.Infra.Repository.Interfaces;

namespace BillReminder.Infra.Repository;
public class BillRepository : BaseWithDeleteRepository<Bill>, IBillRepository
{
    public BillRepository(BillReminderContext context) : base(context)
    {
    }
}
