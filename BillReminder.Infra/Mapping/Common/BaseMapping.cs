using BillReminder.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillReminder.Infra.Mapping.Common;

public class BaseMapping<T> : IEntityTypeConfiguration<T> where T : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CreatedAt)
           .IsRequired()
           .HasColumnName("CreatedAt")
           .HasColumnType("SMALLDATETIME");

        builder.Property(x => x.UpdatedAt)
           .ValueGeneratedOnUpdate()
           .HasColumnName("UpdatedAt")
           .HasColumnType("SMALLDATETIME");
    }
}
