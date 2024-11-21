using MediatR;

namespace Association.Application.Features.DonationGroups.Commands.Delete;
public class DeleteDonationGroupCommand(Guid id) : IRequest<DeletedDonationGroupResponse>
{
    public Guid Id { get; set; } = id;
}
