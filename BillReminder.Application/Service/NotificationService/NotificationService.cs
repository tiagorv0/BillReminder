using BillReminder.Application.Mapper;
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;
using BillReminder.Domain.Entities;
using BillReminder.Infra.Repository.Common;
using BillReminder.Infra.Repository.Interfaces;
using Microsoft.AspNetCore.Http;

namespace BillReminder.Application.Service.NotificationService;
public class NotificationService : BaseService, INotificationService
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IBillRepository _billRepository;

    public NotificationService(IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        INotificationCollector notificationCollector,
        INotificationRepository notificationRepository,
        IBillRepository billRepository) : base(unitOfWork, httpContextAccessor, notificationCollector)
    {
        _notificationRepository = notificationRepository;
        _billRepository = billRepository;
    }

    public async Task<NotificationResponse> CreateNotificationAsync(NotificationRequest request)
    {
        var entity = NotificationMapper.Map(request);

        var notification = await _notificationRepository.CreateAsync(entity);
        await _unitOfWork.CommitAsync();

        return NotificationMapper.Map(notification);
    }

    public async Task BillIsDueTodayNotificationAsync()
    {
        var billsAreDueToday = await _billRepository.GetAllAsync(x => x.Reminder && x.ExpireDate.Date == DateTime.Now.Date && !x.IsPaid);

        var billExpireTodayNotification = new List<Notification>();
        foreach (var bill in billsAreDueToday)
        {
            var notification = new Notification();
            notification.BillIsDueTodayNotification(bill);

            billExpireTodayNotification.Add(notification);
        }

        await _notificationRepository.CreateRangeAsync(billExpireTodayNotification);
        await _unitOfWork.CommitAsync();
    }

    public async Task BillIsDueNotificationAsync()
    {
        var billsAreDue = await _billRepository.GetAllAsync(x => x.Reminder && x.ExpireDate.Date == DateTime.Now.Date.AddDays(-2) && !x.IsPaid);

        var billIsDueNotification = new List<Notification>();
        foreach (var bill in billsAreDue)
        {
            var notification = new Notification();
            notification.BillIsDueNotification(bill);

            billIsDueNotification.Add(notification);
        }

        await _notificationRepository.CreateRangeAsync(billIsDueNotification);
        await _unitOfWork.CommitAsync();
    }

    public async Task BillWasDueNotificationAsync()
    {
        var billsWereDue = await _billRepository.GetAllAsync(x => x.Reminder && !x.IsPaid && 
            (x.ExpireDate.Date == DateTime.Now.Date.AddDays(1) || x.ExpireDate.Date == DateTime.Now.Date.AddDays(7)) );

        var billWasDueNotification = new List<Notification>();
        foreach (var bill in billsWereDue)
        {
            var notification = new Notification();
            notification.BillWasDueNotification(bill);

            billWasDueNotification.Add(notification);
        }

        await _notificationRepository.CreateRangeAsync(billWasDueNotification);
        await _unitOfWork.CommitAsync();
    }
}
