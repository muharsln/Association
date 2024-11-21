using MediatR;

namespace Association.Application.Features.DonationGroups.Queries.GetById;

public class GetByIdDonationGroupQuery(Guid id) : IRequest<GetByIdDonationGroupDto>
{
    public Guid Id { get; } = id;
}
