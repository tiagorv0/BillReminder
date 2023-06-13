using BillReminder.Domain.Entities;
using BillReminder.Infra.Mapping.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillReminder.Infra.Mapping;
public class ReminderMapping : BaseMapping<Reminder>
{
    public override void Configure(EntityTypeBuilder<Reminder> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.IsEnabled)
            .IsRequired()
            .HasColumnType("integer");

        builder.Property(x => x.HowManyDaysToRemind)
            .IsRequired()
            .HasColumnType("integer");

        builder.Property(x => x.HowManyTimes)
            .IsRequired()
            .HasColumnType("integer");

        builder.HasMany(x => x.Notifications)
            .WithOne(x => x.Reminder)
            .HasForeignKey(x => x.ReminderId)
            .HasConstraintName("FK_Reminder_Notification");
    }
}
