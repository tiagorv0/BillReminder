
using BillReminder.Application.Mapper;
using BillReminder.Domain.DTO;
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;
using BillReminder.Domain.Params;
using BillReminder.Infra.Repository.Common;
using BillReminder.Infra.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BillReminder.Application.Service.BillService;

public class BillService : BaseService, IBillService
{
    private readonly IBillRepository _billRepository;
    public BillService(IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        INotificationCollector notificationCollector,
        IBillRepository billRepository
    ) : base(unitOfWork, httpContextAccessor, notificationCollector)
    {
        _billRepository = billRepository;
    }

    public async Task<BillResponse> CreateAsync(BillRequest request)
    {
        var entity = BillMapper.Map(request);

        var createdBill = await _billRepository.CreateAsync(entity);
        await _unitOfWork.CommitAsync();

        return BillMapper.Map(createdBill);
    }

    public async Task<BillResponse> UpdateAsync(Guid id, BillRequest request)
    {
        var bill = await _billRepository.GetByIdAsync(id);
        if (bill is null)
            return default;

        BillMapper.Map(request, bill);

        var updatedBill = await _billRepository.UpdateAsync(bill);
        await _unitOfWork.CommitAsync();

        return BillMapper.Map(updatedBill);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var bill = await _billRepository.GetByIdAsync(id);
        if (bill is null)
            return false;

        await _billRepository.DeleteAsync(bill);
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<BillResponse> GetByIdAsync(Guid id)
    {
        var bill = await _billRepository.GetByIdAsync(id);
        if (bill is null)
            return default;

        return BillMapper.Map(bill);
    }

    public async Task<PagedResponse<BillResponse>> GetBillsAsync(BillParams billParams, Paging page)
    {
        var pages = await _billRepository.GetBillsAsync(GetLoggedUserId(), billParams, page);
        return BillMapper.Map(pages);
    }
}
