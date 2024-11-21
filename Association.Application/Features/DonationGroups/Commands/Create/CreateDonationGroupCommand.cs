using MediatR;

namespace Association.Application.Features.DonationGroups.Commands.Create;
public class CreateDonationGroupCommand : IRequest<CreatedDonationGroupResponse>
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public CreateDonationGroupCommand()
    {
        Name = string.Empty;
        IsActive = true;
    }

    public CreateDonationGroupCommand(string name, bool isActive)
    {
        Name = name;
        IsActive = isActive;
    }
}
