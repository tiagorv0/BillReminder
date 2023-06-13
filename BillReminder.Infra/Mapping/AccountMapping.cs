using BillReminder.Domain.Entities;
using BillReminder.Infra.Mapping.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillReminder.Infra.Mapping;
public class AccountMapping : BaseMapping<Account>
{
    public override void Configure(EntityTypeBuilder<Account> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.HasMany(x => x.Bills)
            .WithOne(x => x.Account)
            .HasForeignKey(x => x.AccountId)
            .HasConstraintName("FK_Account_Bill");
    }
}
