using MediatR;

namespace Association.Application.Features.DonationGroups.Queries.GetById;
public record GetByIdDonationGroupQuery(Guid Id) : IRequest<GetByIdDonationGroupDto>
{
    public Guid Id { get; init; } = Id;
}
