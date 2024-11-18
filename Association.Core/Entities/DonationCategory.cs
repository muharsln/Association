using Association.Core.Entities.Common;

namespace Association.Core.Entities;

public class DonationCategory : BaseEntity<Guid>
{
    public Guid DonationGroupId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public DonationGroup DonationGroup { get; set; }
    public virtual ICollection<DonationOption> DonationOptions { get; set; }
    public virtual ICollection<DonationForm> DonationForms { get; set; }
}
