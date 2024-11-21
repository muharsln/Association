using Association.Application.Features.DonationGroups.Rules;
using Association.Application.Services.DonationGroups;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationGroups.Commands.Update;

public class UpdateDonationGroupCommandHandler : IRequestHandler<UpdateDonationGroupCommand, UpdatedDonationGroupResponse>
{
    private readonly IDonationGroupService _donationGroupService;
    private readonly IMapper _mapper;
    private readonly DonationGroupBusinessRules _donationGroupBusinessRules;

    public UpdateDonationGroupCommandHandler(IDonationGroupService donationGroupService, IMapper mapper, DonationGroupBusinessRules donationGroupBusinessRules)
    {
        _donationGroupService = donationGroupService;
        _mapper = mapper;
        _donationGroupBusinessRules = donationGroupBusinessRules;
    }

    public async Task<UpdatedDonationGroupResponse> Handle(UpdateDonationGroupCommand request, CancellationToken cancellationToken)
    {
        var donationGroup = await _donationGroupService.GetAsync(d => d.Id == request.Id);

        _mapper.Map(request, donationGroup);

        await _donationGroupBusinessRules.CheckIfDonationGroupIdExists(donationGroup);
        await _donationGroupBusinessRules.CheckIfDonationGroupNameExists(donationGroup);

        await _donationGroupService.UpdateAsync(donationGroup);

        UpdatedDonationGroupResponse response = _mapper.Map<UpdatedDonationGroupResponse>(donationGroup);
        return response;
    }
}