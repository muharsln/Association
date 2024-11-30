using MediatR;

namespace Association.Application.Features.DonationShares.Queries.GetList;
public record GetListDonationShareQuery() : IRequest<ICollection<GetListDonationShareDto>>;
