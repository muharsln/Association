using Association.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Association.Persistence.EntityConfigurations;
public class DonationShareConfiguration : IEntityTypeConfiguration<DonationShare>
{
    public void Configure(EntityTypeBuilder<DonationShare> builder)
    {
        builder.ToTable("DonationShares").HasKey(ds => ds.Id);

        builder.Property(ds => ds.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(ds => ds.DonationFormId)
            .HasColumnName("DonationFormId")
            .IsRequired();

        builder.Property(ds => ds.DonationOptionId)
            .HasColumnName("DonationOptionId")
            .IsRequired();

        builder.Property(ds => ds.IntentionTypeId)
            .HasColumnName("IntentionTypeId")
            .IsRequired();

        builder.Property(ds => ds.FirstName)
            .HasColumnName("FirstName")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(ds => ds.LastName)
            .HasColumnName("LastName")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(ds => ds.Phone)
            .HasColumnName("Phone")
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(ds => ds.ShareAmount)
            .HasColumnName("ShareAmount")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasOne(ds => ds.DonationOption)
            .WithMany(dop => dop.DonationShares)
            .HasForeignKey(ds => ds.DonationOptionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ds => ds.DonationForm)
            .WithMany(dop => dop.DonationShares)
            .HasForeignKey(ds => ds.DonationFormId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ds => ds.IntentionType)
            .WithMany(it => it.DonationShares)
            .HasForeignKey(ds => ds.IntentionTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
