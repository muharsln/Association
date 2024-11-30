using Association.Core.Entities.Common;

namespace Association.Core.Entities;

public class DonationForm : BaseEntity<Guid>
{
    public Guid DonorId { get; set; }
    public Guid DonationCategoryId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreateDate { get; set; }

    public Donor Donor { get; set; }
    public DonationCategory DonationCategory { get; set; }

    public virtual ICollection<DonationShare> DonationShares { get; set; }
}
