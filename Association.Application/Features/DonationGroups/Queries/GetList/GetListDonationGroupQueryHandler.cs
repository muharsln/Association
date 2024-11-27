using Association.Application.Services.DonationGroups;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationGroups.Queries.GetList;
public class GetListDonationGroupQueryHandler(IDonationGroupService donationGroupService, IMapper mapper) : IRequestHandler<GetListDonationGroupQuery, IEnumerable<GetListDonationGroupDto>>
{
    public async Task<IEnumerable<GetListDonationGroupDto>> Handle(GetListDonationGroupQuery request, CancellationToken cancellationToken)
    {
        var donationGroups = await donationGroupService.GetListAsync();
        return mapper.Map<IEnumerable<GetListDonationGroupDto>>(donationGroups);
    }
}
