
using BillReminder.Application.Mapper;
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;
using BillReminder.Infra.Repository.Common;
using BillReminder.Infra.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BillReminder.Application.Service.ReminderService;

public class ReminderService : BaseService, IReminderService
{
    private readonly IReminderRepository _repository;

    public ReminderService(IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        INotificationCollector notificationCollector,
        IReminderRepository repository) : base(unitOfWork, httpContextAccessor, notificationCollector)
    {
        _repository = repository;
    }

    public async Task<ReminderResponse> CreateAsync(ReminderRequest request)
    {
        var entity = ReminderMapper.Map(request);

        var created = await _repository.CreateAsync(entity);
        await _unitOfWork.CommitAsync();

        return ReminderMapper.Map(created);
    }

    public async Task<ReminderResponse> UpdateAsync(Guid id, ReminderRequest request)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return default;

        ReminderMapper.Map(request, entity);

        var updated = await _repository.UpdateAsync(entity);
        await _unitOfWork.CommitAsync();

        return ReminderMapper.Map(updated);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return default;

        await _repository.DeleteAsync(entity);
        await _unitOfWork.CommitAsync();

        return true;
    }

    public async Task<ReminderResponse> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null)
            return default;

        return ReminderMapper.Map(entity);
    }
}
