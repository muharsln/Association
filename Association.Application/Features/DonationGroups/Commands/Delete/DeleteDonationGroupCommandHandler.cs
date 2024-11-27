using Association.Application.Features.DonationGroups.Rules;
using Association.Application.Services.DonationGroups;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationGroups.Commands.Delete;
public class DeleteDonationGroupCommandHandler(IDonationGroupService donationGroupService, IMapper mapper, DonationGroupBusinessRules donationGroupBusinessRules) : IRequestHandler<DeleteDonationGroupCommand, DeletedDonationGroupResponse>
{
    public async Task<DeletedDonationGroupResponse> Handle(DeleteDonationGroupCommand request, CancellationToken cancellationToken)
    {
        var donationGroup = mapper.Map<DonationGroup>(request);

        await donationGroupBusinessRules.CheckIfDonationGroupIdExistsAsync(donationGroup);
        await donationGroupBusinessRules.CheckIfDonationGroupHasDonationCategoriesAsync(donationGroup);

        var deletedDonationGroup = await donationGroupService.DeleteAsync(donationGroup);

        return mapper.Map<DeletedDonationGroupResponse>(deletedDonationGroup);       
    }
}
