using MediatR;

namespace Association.Application.Features.DonationGroups.Commands.Update;
public class UpdateDonationGroupCommand : IRequest<UpdatedDonationGroupResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
