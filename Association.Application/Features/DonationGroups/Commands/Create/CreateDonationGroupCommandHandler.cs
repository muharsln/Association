using Association.Application.Features.DonationGroups.Rules;
using Association.Application.Services.DonationGroups;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationGroups.Commands.Create;
public class CreateDonationGroupCommandHandler(IDonationGroupService donationGroupService, IMapper mapper, DonationGroupBusinessRules donationGroupBusinessRules) : IRequestHandler<CreateDonationGroupCommand, CreatedDonationGroupResponse>
{
    public async Task<CreatedDonationGroupResponse> Handle(CreateDonationGroupCommand request, CancellationToken cancellationToken)
    {
        var donationGroup = mapper.Map<DonationGroup>(request);
        await donationGroupBusinessRules.CheckIfDonationGroupNameExistsAsync(donationGroup);

        var createdDonationGroup = await donationGroupService.AddAsync(donationGroup);

        return mapper.Map<CreatedDonationGroupResponse>(createdDonationGroup);;
    }
}
