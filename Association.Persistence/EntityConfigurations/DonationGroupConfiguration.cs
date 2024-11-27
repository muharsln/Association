using Association.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Association.Persistence.EntityConfigurations;
public class DonationGroupConfiguration : IEntityTypeConfiguration<DonationGroup>
{
    public void Configure(EntityTypeBuilder<DonationGroup> builder)
    {
        builder.ToTable("DonationGroups").HasKey(dg => dg.Id);

        builder.Property(dg => dg.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(dg => dg.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(dg => dg.IsActive)
            .HasColumnName("IsActive")
            .IsRequired();

        builder.HasMany(dg => dg.DonationCategories)
            .WithOne(dc => dc.DonationGroup)
            .HasForeignKey(dc => dc.DonationGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(dg => dg.Name).IsUnique();
    }
}
