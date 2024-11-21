using MediatR;

namespace Association.Application.Features.DonationGroups.Queries.GetList;

public class GetListDonationGroupQuery : IRequest<IEnumerable<GetListDonationGroupDto>> { }
