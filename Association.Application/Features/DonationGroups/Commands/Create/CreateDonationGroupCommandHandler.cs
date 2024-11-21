using Association.Application.Features.DonationGroups.Rules;
using Association.Application.Services.DonationGroups;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationGroups.Commands.Create;

public class CreateDonationGroupCommandHandler : IRequestHandler<CreateDonationGroupCommand, CreatedDonationGroupResponse>
{
    private readonly IDonationGroupService _donationGroupService;
    private readonly IMapper _mapper;
    private readonly DonationGroupBusinessRules _donationGroupBusinessRules;

    public CreateDonationGroupCommandHandler(IDonationGroupService donationGroupService, IMapper mapper, DonationGroupBusinessRules donationGroupBusinessRules)
    {
        _donationGroupService = donationGroupService;
        _mapper = mapper;
        _donationGroupBusinessRules = donationGroupBusinessRules;
    }

    public async Task<CreatedDonationGroupResponse> Handle(CreateDonationGroupCommand request, CancellationToken cancellationToken)
    {
        DonationGroup donationGroup = _mapper.Map<DonationGroup>(request);
        await _donationGroupBusinessRules.CheckIfDonationGroupNameExists(donationGroup);

        var createdDonationGroup = await _donationGroupService.AddAsync(donationGroup);

        CreatedDonationGroupResponse response = _mapper.Map<CreatedDonationGroupResponse>(createdDonationGroup);

        return response;
    }
}
