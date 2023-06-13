using BillReminder.Infra.Repository.Common;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BillReminder.Application.Service;

public abstract class BaseService
{
    protected readonly IUnitOfWork _unitOfWork;

    protected readonly IHttpContextAccessor _httpContextAccessor;
    protected readonly INotificationCollector _notificationCollector;

    protected BaseService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, INotificationCollector notificationCollector)
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
        _notificationCollector = notificationCollector;
    }

    protected IEnumerable<Claim> GetUserClaims()
    {
        return _httpContextAccessor.HttpContext!.User.Claims;
    }

    protected Guid GetLoggedUserId()
    {
        return Guid.Parse(GetUserClaims().SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value);
    }
}
