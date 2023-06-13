
using BillReminder.Domain.DTO.Request;
using BillReminder.Domain.DTO.Response;
using BillReminder.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace BillReminder.Application.Mapper;

[Mapper]
public static partial class UserMapper
{
    [MapProperty(nameof(UserRequest.Password), nameof(User.HashedPassword))]
    public static partial User Map(UserRequest request);
    public static partial UserResponse Map(User entity);
    public static partial IEnumerable<UserResponse> Map(IEnumerable<User> list);
    public static partial void Map(UserRequest request, User entity);
}
