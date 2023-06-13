using BillReminder.Domain.Entities;
using BillReminder.Infra.Mapping.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillReminder.Infra.Mapping;
public class UserMapping : BaseMapping<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(80);

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.HashedPassword)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasMany(x => x.Accounts)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .HasConstraintName("FK_User_Account");
    }
}
