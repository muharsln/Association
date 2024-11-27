using Association.Core.Entities;
using Association.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace Association.Persistence.Context;
public class AssociationDbContext(DbContextOptions options) : DbContext(options)
{
    public required DbSet<DonationGroup> DonationGroups { get; set; }
    public required DbSet<DonationCategory> DonationCategories { get; set; }
    public required DbSet<DonationOption> DonationOptions { get; set; }
    public required DbSet<DonationForm> DonationForms { get; set; }
    public required DbSet<Donor> Donors { get; set; }
    public required DbSet<DonationShare> DonationShares { get; set; }
    public required DbSet<IntentionType> IntentionTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
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
