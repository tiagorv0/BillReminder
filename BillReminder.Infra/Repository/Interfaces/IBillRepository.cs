using BillReminder.Domain.DTO;
using BillReminder.Domain.Entities;
using BillReminder.Domain.Params;
using BillReminder.Infra.Repository.Common;

namespace BillReminder.Infra.Repository.Interfaces;
public interface IBillRepository : IBaseWithDeleteRepository<Bill>
{
    Task<PagedResponse<Bill>> GetBillsAsync(Guid userId, BillParams billParams, Paging page);
}
