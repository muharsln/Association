using Association.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Association.Persistence.EntityConfigurations;
public class DonorConfiguration : IEntityTypeConfiguration<Donor>
{
    public void Configure(EntityTypeBuilder<Donor> builder)
    {
        builder.ToTable("Donors").HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(d => d.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(d => d.Surname)
            .HasColumnName("Surname")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(d => d.Email)
            .HasColumnName("Email")
            .HasMaxLength(100);

        builder.Property(d => d.Phone)
            .HasColumnName("Phone")
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(d => d.Location)
            .HasColumnName("Location")
            .HasMaxLength(50);

        builder.Property(d => d.IsActive)
            .HasColumnName("IsActive")
            .IsRequired();

        builder.HasMany(d => d.DonationForms)
               .WithOne(df => df.Donor)
               .HasForeignKey(df => df.DonorId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
