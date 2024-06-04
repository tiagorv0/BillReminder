using BillReminder.Domain.Entities;
using BillReminder.Infra.Mapping.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillReminder.Infra.Mapping;
public class BillMapping : BaseMapping<Bill>
{
    public override void Configure(EntityTypeBuilder<Bill> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.Value)
            .IsRequired()
            .HasColumnType("DECIMAL(18,2)");

        builder.Property(x => x.ExpireDate)
            .IsRequired();

        builder.Property(x => x.Comment)
            .HasMaxLength(100);

        builder.HasMany(x => x.Notifications)
            .WithOne(x => x.Bill)
            .HasForeignKey(x => x.BillId)
            .HasConstraintName("FK_Bill_Notification")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
