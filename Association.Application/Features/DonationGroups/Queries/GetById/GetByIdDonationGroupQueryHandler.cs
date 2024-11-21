using Association.Application.Features.DonationGroups.Rules;
using Association.Application.Services.DonationGroups;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationGroups.Queries.GetById;

public class GetByIdDonationGroupQueryHandler : IRequestHandler<GetByIdDonationGroupQuery, GetByIdDonationGroupDto>
{
    private readonly IMapper _mapper;
    private readonly IDonationGroupService _donationGroupService;
    private readonly DonationGroupBusinessRules _donationGroupBusinessRules;

    public GetByIdDonationGroupQueryHandler(IMapper mapper, IDonationGroupService donationGroupService, DonationGroupBusinessRules donationGroupBusinessRules)
    {
        _mapper = mapper;
        _donationGroupService = donationGroupService;
        _donationGroupBusinessRules = donationGroupBusinessRules;
    }

    public async Task<GetByIdDonationGroupDto> Handle(GetByIdDonationGroupQuery request, CancellationToken cancellationToken)
    {
        var donationGroup = _mapper.Map<DonationGroup>(request);

        await _donationGroupBusinessRules.CheckIfDonationGroupIdExists(donationGroup);

        donationGroup = await _donationGroupService.GetAsync(predicate: d => d.Id == request.Id);

        return _mapper.Map<GetByIdDonationGroupDto>(donationGroup);
    }
}
