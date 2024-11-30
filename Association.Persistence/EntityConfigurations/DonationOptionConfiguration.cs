using Association.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Association.Persistence.EntityConfigurations;
public class DonationOptionConfiguration : IEntityTypeConfiguration<DonationOption>
{
    public void Configure(EntityTypeBuilder<DonationOption> builder)
    {
        builder.ToTable("DonationOptions").HasKey(dop => dop.Id);

        builder.Property(dop => dop.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(dop => dop.DonationCategoryId)
            .HasColumnName("DonationCategoryId")
            .IsRequired();

        builder.Property(dop => dop.Sequence)
            .HasColumnName("Sequence")
            .IsRequired();

        builder.Property(dop => dop.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(dop => dop.Price)
            .HasColumnName("Price")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(dop => dop.IsActive)
            .HasColumnName("IsActive")
            .IsRequired();

        builder.Property(dop => dop.Currency)
            .HasColumnName("Currency")
            .IsRequired();

        builder.HasOne(dop => dop.DonationCategory)
            .WithMany(dc => dc.DonationOptions)
            .HasForeignKey(dop => dop.DonationCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(dop => dop.DonationShares)
            .WithOne(ds => ds.DonationOption)
            .HasForeignKey(ds => ds.DonationOptionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(dop => dop.Name);
    }
}
