using MediatR;

namespace Association.Application.Features.DonationGroups.Commands.Create;
public record CreateDonationGroupCommand(string Name, bool IsActive) : IRequest<CreatedDonationGroupResponse>
{
    public CreateDonationGroupCommand() : this(string.Empty, true) { }
}
