using Association.Core.Entities.Common;

namespace Association.Core.Entities;

public class Donor : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Location { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<DonationForm>? DonationForms { get; set; } 
}
