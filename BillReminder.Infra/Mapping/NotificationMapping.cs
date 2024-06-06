using BillReminder.Domain.Entities;
using BillReminder.Infra.Mapping.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillReminder.Infra.Mapping;
public class NotificationMapping : BaseMapping<Notification>
{
    public override void Configure(EntityTypeBuilder<Notification> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Message)
            .IsRequired()
            .HasMaxLength(255);
    }
}
