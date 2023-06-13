using BillReminder.Application.Mapper;
using BillReminder.Application.Service;
using BillReminder.Application.Service.Caching;
using BillReminder.Application.Service.Jwt;
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;
using BillReminder.Domain.Entities;
using BillReminder.Domain.Exceptions;
using BillReminder.Infra.Repository.Common;
using BillReminder.Infra.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using SecureIdentity.Password;
using System.Text.Json;

namespace BillReminder.Application.Service.UserService;

public class UserService : BaseService, IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    private readonly ICachingService _cachingService;
    public UserService(IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor,
        INotificationCollector notificationCollector,
        IUserRepository userRepository,
        IJwtService jwtService,
        ICachingService cachingService) : base(unitOfWork, httpContextAccessor, notificationCollector)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _cachingService = cachingService;
    }

    public async Task<UserResponse> CreateAsync(UserRequest request)
    {
        var entity = UserMapper.Map(request);

        entity.HashedPassword = PasswordHasher.Hash(request.Password);

        var created = await _userRepository.CreateAsync(entity);
        await _unitOfWork.CommitAsync();

        return UserMapper.Map(created);
    }

    public async Task<UserResponse> UpdateAsync(Guid id, UserRequest request)
    {
        var entity = await _userRepository.GetByIdAsync(id);
        if (entity is null)
            return default;

        UserMapper.Map(request, entity);
        entity.HashedPassword = PasswordHasher.Hash(request.Password);

        var updated = await _userRepository.UpdateAsync(entity);
        await _unitOfWork.CommitAsync();

        return UserMapper.Map(updated);
    }

    public async Task<UserResponse> GetOwnUserAsync()
    {
        var id = GetLoggedUserId();
        var cache = await _cachingService.GetAsync(id.ToString());
        if (cache is null)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            await _cachingService.SetAsync(id.ToString(), JsonSerializer.Serialize(entity));
            return UserMapper.Map(entity);
        }

        var entityCached = JsonSerializer.Deserialize<User>(cache);
        return UserMapper.Map(entityCached);
    }

    public async Task<TokenResponse> HandleLoginAsync(LoginRequest login)
    {
        var user = await _userRepository.GetByEmail(login.Email);
        if (!PasswordHasher.Verify(user.HashedPassword, login.Password) || user is null)
        {
            _notificationCollector.AddNotification(NotificationMessages.LoginInvalido);
            return default;
        }

        var token = _jwtService.GenerateToken(user);

        return new TokenResponse(token);
    }
}
