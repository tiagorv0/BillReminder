using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;

namespace BillReminder.Application.Service.UserService;

public interface IUserService
{
    Task<UserResponse> CreateAsync(UserRequest request);
    Task<UserResponse> UpdateAsync(Guid id, UserRequest request);
    Task<UserResponse> GetOwnUserAsync();
    Task<TokenResponse> HandleLoginAsync(LoginRequest login);
}
