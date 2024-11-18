using Association.Core.Entities.Common;

namespace Association.Core.Entities;

public class DonationGroup : BaseEntity<Guid>
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<DonationCategory> DonationCategories { get; set; }
}