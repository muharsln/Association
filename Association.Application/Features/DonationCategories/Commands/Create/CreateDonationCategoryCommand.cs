using MediatR;

namespace Association.Application.Features.DonationCategories.Commands.Create;
public class CreateDonationCategoryCommand : IRequest<CreatedDonationCategoryResponse>
{
    public Guid DonationGroupId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public CreateDonationCategoryCommand()
    {
        Name = string.Empty;
        IsActive = true;
    }

    public CreateDonationCategoryCommand(Guid donationGroupId, string name, bool isActive)
    {
        DonationGroupId = donationGroupId;
        Name = name;
        IsActive = isActive;
    }
}
