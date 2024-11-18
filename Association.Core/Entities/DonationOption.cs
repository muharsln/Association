using Association.Core.Entities.Common;
using Association.Core.Enums;

namespace Association.Core.Entities;

public class DonationOption : BaseEntity<Guid>
{
    public Guid DonationCategoryId { get; set; }
    public int OptionSequence { get; set; }
    public string OptionName { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public Currency Currency { get; set; }


    public DonationCategory DonationCategory;
    public virtual ICollection<DonationShare> DonationShares { get; set; }
}
