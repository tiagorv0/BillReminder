
using BillReminder.Domain.Entities;

namespace BillReminder.Application.Service.Jwt;

public interface IJwtService
{
    string GenerateToken(User user);
}
