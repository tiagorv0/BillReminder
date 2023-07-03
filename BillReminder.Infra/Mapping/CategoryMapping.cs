using BillReminder.Domain.Entities;
using BillReminder.Infra.Mapping.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillReminder.Infra.Mapping;
public class CategoryMapping : BaseMapping<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.HasMany(x => x.Bills)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId)
            .HasConstraintName("FK_Category_Bill")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Account)
            .WithMany()
            .HasForeignKey(x => x.AccountId)
            .HasConstraintName("FK_Category_Account");
    }
}
