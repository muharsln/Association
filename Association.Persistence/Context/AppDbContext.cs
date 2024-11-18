using Association.Core.Entities;
using Association.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Association.Persistence.Context;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<DonationGroup> DonationGroups { get; set; }
    public DbSet<DonationCategory> DonationCategories { get; set; }
    public DbSet<DonationOption> DonationOptions { get; set; }
    public DbSet<DonationForm> DonationForms { get; set; }
    public DbSet<Donor> Donors { get; set; }
    public DbSet<DonationShare> DonationShares { get; set; }
    public DbSet<IntentionType> IntentionTypes { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // DonationGroup to DonationCategory
        modelBuilder.Entity<DonationGroup>()
            .HasMany(dg => dg.DonationCategories)
            .WithOne(dc => dc.DonationGroup)
            .HasForeignKey(dc => dc.DonationGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        // DonationCategory to DonationOption
        modelBuilder.Entity<DonationCategory>()
            .HasMany(dc => dc.DonationOptions)
            .WithOne(dop => dop.DonationCategory)
            .HasForeignKey(dop => dop.DonationCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // DonationCategory to DonationForm
        modelBuilder.Entity<DonationCategory>()
            .HasMany(dc => dc.DonationForms)
            .WithOne(df => df.DonationCategory)
            .HasForeignKey(df => df.DonationCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // DonationOption to DonationShare
        modelBuilder.Entity<DonationOption>()
            .HasMany(dop => dop.DonationShares)
            .WithOne(ds => ds.DonationOption)
            .HasForeignKey(ds => ds.DonationOptionId)
            .OnDelete(DeleteBehavior.Restrict);

        // DonationForm to DonationShare
        modelBuilder.Entity<DonationForm>()
            .HasMany(df => df.DonationShares)
            .WithOne(ds => ds.DonationForm)
            .HasForeignKey(ds => ds.DonationFormId)
            .OnDelete(DeleteBehavior.Restrict);

        // Donor to DonationForm
        modelBuilder.Entity<Donor>()
            .HasMany(d => d.DonationForms)
            .WithOne(df => df.Donor)
            .HasForeignKey(df => df.DonorId)
            .OnDelete(DeleteBehavior.Restrict);

        // IntentionType to DonationShare
        modelBuilder.Entity<IntentionType>()
            .HasMany(it => it.DonationShares)
            .WithOne(ds => ds.IntentionType)
            .HasForeignKey(ds => ds.IntentionTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity<Guid>>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.Id = Guid.NewGuid();
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}
