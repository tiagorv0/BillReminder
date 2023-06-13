using BillReminder.Domain.Entities;
using BillReminder.Infra.Context;
using BillReminder.Infra.Repository.Common;
using BillReminder.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BillReminder.Infra.Repository;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(BillReminderContext context) : base(context)
    {
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
    }
}
