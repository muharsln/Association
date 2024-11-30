using MediatR;

namespace Association.Application.Features.DonationGroups.Queries.GetList;
public record GetListDonationGroupQuery() : IRequest<IEnumerable<GetListDonationGroupDto>>;
