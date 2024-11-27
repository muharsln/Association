using MediatR;

namespace Association.Application.Features.DonationGroups.Commands.Update;
public record UpdateDonationGroupCommand(Guid Id, string Name) : IRequest<UpdatedDonationGroupResponse>
{
    public Guid Id { get; set; } = Id;
}
