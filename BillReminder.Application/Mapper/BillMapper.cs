
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;
using BillReminder.Domain.DTO;
using BillReminder.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace BillReminder.Application.Mapper;

[Mapper]
public static partial class BillMapper
{
    
    public static partial Bill Map(BillRequest request);

    public static partial BillResponse Map(Bill entity);
    public static partial IEnumerable<BillResponse> Map(IEnumerable<Bill> list);
    public static partial void Map(BillRequest request, Bill entity);
    public static partial PagedResponse<BillResponse> Map(PagedResponse<Bill> list);
}
