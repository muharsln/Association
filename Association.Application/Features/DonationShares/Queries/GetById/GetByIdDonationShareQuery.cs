using MediatR;

namespace Association.Application.Features.DonationShares.Queries.GetById;
public record GetByIdDonationShareQuery(Guid Id) : IRequest<GetByIdDonationShareDto>;
