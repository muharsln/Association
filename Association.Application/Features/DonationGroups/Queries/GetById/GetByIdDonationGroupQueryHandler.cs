using Association.Application.Features.DonationGroups.Rules;
using Association.Application.Services.DonationGroups;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationGroups.Queries.GetById;
public class GetByIdDonationGroupQueryHandler(IMapper mapper, IDonationGroupService donationGroupService, DonationGroupBusinessRules donationGroupBusinessRules) : IRequestHandler<GetByIdDonationGroupQuery, GetByIdDonationGroupDto>
{
    public async Task<GetByIdDonationGroupDto> Handle(GetByIdDonationGroupQuery request, CancellationToken cancellationToken)
    {
        var donationGroup = mapper.Map<DonationGroup>(request);

        await donationGroupBusinessRules.CheckIfDonationGroupIdExistsAsync(donationGroup);

        donationGroup = await donationGroupService.GetAsync(predicate: d => d.Id == request.Id);

        return mapper.Map<GetByIdDonationGroupDto>(donationGroup);
    }
}
