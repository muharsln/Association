using MediatR;

namespace Association.Application.Features.DonationGroups.Commands.Delete;
public record DeleteDonationGroupCommand(Guid Id) : IRequest<DeletedDonationGroupResponse>
{
    public Guid Id { get; init; } = Id;
}
