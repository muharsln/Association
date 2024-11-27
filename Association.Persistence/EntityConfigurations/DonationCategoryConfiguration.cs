using Association.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Association.Persistence.EntityConfigurations;
public class DonationCategoryConfiguration : IEntityTypeConfiguration<DonationCategory>
{
    public void Configure(EntityTypeBuilder<DonationCategory> builder)
    {
        // Table configuration
        builder.ToTable("DonationCategories").HasKey(dc => dc.Id);

        // Property configurations
        builder.Property(dc => dc.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(dc => dc.DonationGroupId)
            .HasColumnName("DonationGroupId")
            .IsRequired();

        builder.Property(dc => dc.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(dc => dc.IsActive)
            .HasColumnName("IsActive")
            .IsRequired();

        // Relationship configurations
        builder.HasMany(dc => dc.DonationOptions)
               .WithOne(dop => dop.DonationCategory)
               .HasForeignKey(dop => dop.DonationCategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(dc => dc.DonationForms)
               .WithOne(df => df.DonationCategory)
               .HasForeignKey(df => df.DonationCategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(dc => dc.DonationGroup)
               .WithMany(dg => dg.DonationCategories)
               .HasForeignKey(dc => dc.DonationGroupId)
               .OnDelete(DeleteBehavior.Restrict);

        // Index configuration
        builder.HasIndex(dc => dc.Name).IsUnique();
    }
}
