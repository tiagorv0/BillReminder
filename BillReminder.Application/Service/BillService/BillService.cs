
using BillReminder.Application.Mapper;
using BillReminder.Domain.DTO;
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;
using BillReminder.Domain.Entities;
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

    public async Task CreateBillRecurrencyAsync()
    {
        var bills = await _billRepository.GetAllAsync(x => x.Recurrency && x.CreatedAt >= DateTime.Now.AddMonths(-1));

        var billsOfCurrentMonth = new List<Bill>();
        foreach (var bill in bills)
        {
            var billOfCurrentMonth = new Bill
            {
                Name = bill.Name,
                Value = bill.Value,
                Status = bill.Status,
                ReferenceMonth = bill.ReferenceMonth,
                ExpireDate = bill.ExpireDate.AddMonths(1),
                Comment = bill.Comment,
                IsPaid = bill.IsPaid,
                CategoryId = bill.CategoryId,
                AccountId = bill.AccountId,
                Reminder = bill.Reminder,
                Recurrency = bill.Recurrency,
            };

            billsOfCurrentMonth.Add(billOfCurrentMonth);
        }

        await _billRepository.CreateRangeAsync(billsOfCurrentMonth);
        await _unitOfWork.CommitAsync();
    }
}
