using Association.Application.Services.DonationGroups;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationGroups.Queries.GetList;

public class GetListDonationGroupQueryHandler : IRequestHandler<GetListDonationGroupQuery, IEnumerable<GetListDonationGroupDto>>
{
    private readonly IDonationGroupService _donationGroupService;
    private readonly IMapper _mapper;

    public GetListDonationGroupQueryHandler(IDonationGroupService donationGroupService, IMapper mapper)
    {
        _donationGroupService = donationGroupService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetListDonationGroupDto>> Handle(GetListDonationGroupQuery request, CancellationToken cancellationToken)
    {
        var donationGroups = await _donationGroupService.GetListAsync();
        return _mapper.Map<IEnumerable<GetListDonationGroupDto>>(donationGroups);
    }
}