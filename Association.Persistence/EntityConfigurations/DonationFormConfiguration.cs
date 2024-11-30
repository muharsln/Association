using Association.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Association.Persistence.EntityConfigurations;
public class DonationFormConfiguration : IEntityTypeConfiguration<DonationForm>
{
    public void Configure(EntityTypeBuilder<DonationForm> builder)
    {
        builder.ToTable("DonationForms").HasKey(df => df.Id);

        builder.Property(df => df.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(df => df.DonorId)
            .HasColumnName("DonorId")
            .IsRequired();

        builder.Property(df => df.DonationCategoryId)
            .HasColumnName("DonationCategoryId")
            .IsRequired();

        builder.Property(df => df.TotalPrice)
            .HasColumnName("TotalPrice")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(df => df.CreateDate)
            .HasColumnName("CreateDate")
            .IsRequired();

        builder.HasOne(df => df.Donor)
            .WithMany(d => d.DonationForms)
            .HasForeignKey(df => df.DonorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(df => df.DonationCategory)
            .WithMany(dc => dc.DonationForms)
            .HasForeignKey(df => df.DonationCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(df => df.DonationShares)
            .WithOne(ds => ds.DonationForm)
            .HasForeignKey(ds => ds.DonationFormId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
