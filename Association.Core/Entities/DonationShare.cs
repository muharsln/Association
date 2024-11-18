using Association.Core.Entities.Common;

namespace Association.Core.Entities;

public class DonationShare : BaseEntity<Guid>
{
    public Guid DonationFormId { get; set; }
    public Guid DonationOptionId { get; set; }
    public Guid IntentionTypeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public decimal ShareAmount { get; set; }

    public DonationOption DonationOption { get; set; }
    public DonationForm DonationForm { get; set; }
    public IntentionType IntentionType { get; set; }
}
