using Association.Application.Features.DonationGroups.Rules;
using Association.Application.Services.DonationGroups;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationGroups.Commands.Update;
public class UpdateDonationGroupCommandHandler(IDonationGroupService donationGroupService, IMapper mapper, DonationGroupBusinessRules donationGroupBusinessRules) : IRequestHandler<UpdateDonationGroupCommand, UpdatedDonationGroupResponse>
{
    public async Task<UpdatedDonationGroupResponse> Handle(UpdateDonationGroupCommand request, CancellationToken cancellationToken)
    {
        var donationGroup = await donationGroupService.GetAsync(d => d.Id == request.Id);

        mapper.Map(request, donationGroup);

        await donationGroupBusinessRules.CheckIfDonationGroupIdExistsAsync(donationGroup);
        await donationGroupBusinessRules.CheckIfDonationGroupNameExistsAsync(donationGroup);

        await donationGroupService.UpdateAsync(donationGroup);

        UpdatedDonationGroupResponse response = mapper.Map<UpdatedDonationGroupResponse>(donationGroup);
        return response;
    }
}
