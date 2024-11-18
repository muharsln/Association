using Association.Core.Entities.Common;

namespace Association.Core.Entities;

public class IntentionType : BaseEntity<Guid>
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<DonationShare> DonationShares { get; set; }
}