using Association.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Association.Persistence.EntityConfigurations;
public class IntentionTypeConfiguration : IEntityTypeConfiguration<IntentionType>
{
    public void Configure(EntityTypeBuilder<IntentionType> builder)
    {
        builder.ToTable("IntentionTypes").HasKey(it => it.Id);

        builder.Property(it => it.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(it => it.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(it => it.IsActive)
            .HasColumnName("IsActive")
            .IsRequired();

        builder.HasMany(it => it.DonationShares)
            .WithOne(ds => ds.IntentionType)
            .HasForeignKey(ds => ds.IntentionTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(it => it.Name).IsUnique();
    }
}
