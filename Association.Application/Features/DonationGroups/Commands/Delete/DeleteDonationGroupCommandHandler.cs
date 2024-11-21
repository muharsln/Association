using Association.Application.Features.DonationGroups.Rules;
using Association.Application.Services.DonationGroups;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationGroups.Commands.Delete;

public class DeleteDonationGroupCommandHandler : IRequestHandler<DeleteDonationGroupCommand, DeletedDonationGroupResponse>
{
    private readonly IDonationGroupService _donationGroupService;
    private readonly IMapper _mapper;
    private readonly DonationGroupBusinessRules _donationGroupBusinessRules;

    public DeleteDonationGroupCommandHandler(IDonationGroupService donationGroupService, IMapper mapper, DonationGroupBusinessRules donationGroupBusinessRules)
    {
        _donationGroupService = donationGroupService;
        _mapper = mapper;
        _donationGroupBusinessRules = donationGroupBusinessRules;
    }

    public async Task<DeletedDonationGroupResponse> Handle(DeleteDonationGroupCommand request, CancellationToken cancellationToken)
    {
        DonationGroup donationGroup = _mapper.Map<DonationGroup>(request);

        await _donationGroupBusinessRules.CheckIfDonationGroupIdExists(donationGroup);
        await _donationGroupBusinessRules.CheckIfDonationGroupHasDonationCategories(donationGroup);

        DonationGroup deletedDonationGroup = await _donationGroupService.DeleteAsync(donationGroup);

        DeletedDonationGroupResponse response = _mapper.Map<DeletedDonationGroupResponse>(deletedDonationGroup);

        return response;
    }
}
