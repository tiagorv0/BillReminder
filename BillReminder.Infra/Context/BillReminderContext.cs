using BillReminder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BillReminder.Infra.Context;
public class BillReminderContext : DbContext
{
    public BillReminderContext(DbContextOptions<BillReminderContext> options) : base(options)
    {

    }

    public DbSet<Reminder> Reminders { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Notification> Notifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BillReminderContext).Assembly);
    }
}
