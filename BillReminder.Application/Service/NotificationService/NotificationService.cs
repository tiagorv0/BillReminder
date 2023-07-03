using BillReminder.Application.Mapper;
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;
using BillReminder.Infra.Repository.Common;
using BillReminder.Infra.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BillReminder.Application.Service.NotificationService;
public class NotificationService : BaseService, INotificationService
{
    private readonly INotificationRepository _notificationRepository;

    public NotificationService(IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        INotificationCollector notificationCollector,
        INotificationRepository notificationRepository
        ) : base(unitOfWork, httpContextAccessor, notificationCollector)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<NotificationResponse> CreateNotificationAsync(BillRequest request)
    {
        var notification = await _notificationRepository.CreateAsync();
        await _unitOfWork.CommitAsync();

        return NotificationMapper.Map(notification);
    }

    public NotificationResponse FactoryNotification()
    {
        return new(

            );
    }
}
