using Association.Application.Features.DonationCategories.Rules;
using Association.Application.Services.DonationCategories;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationCategories.Commands.Create;

public class CreateDonationCategoryCommandHandler : IRequestHandler<CreateDonationCategoryCommand, CreatedDonationCategoryResponse>
{
    private readonly IDonationCategoryService _donationCategoryService;
    private readonly IMapper _mapper;
    private readonly DonationCategoryBusinessRules _donationCategoryBusinessRules;

    public CreateDonationCategoryCommandHandler(IDonationCategoryService donationCategoryService, IMapper mapper, DonationCategoryBusinessRules donationCategoryBusinessRules)
    {
        _donationCategoryService = donationCategoryService;
        _mapper = mapper;
        _donationCategoryBusinessRules = donationCategoryBusinessRules;
    }

    public async Task<CreatedDonationCategoryResponse> Handle(CreateDonationCategoryCommand request, CancellationToken cancellationToken)
    {
        var donationCategory = _mapper.Map<DonationCategory>(request);
        await _donationCategoryBusinessRules.CheckIfNameExists(donationCategory);
        await _donationCategoryBusinessRules.CheckIfDonationGroupExists(donationCategory);
        var createdDonationCategory = await _donationCategoryService.AddAsync(donationCategory);
        return _mapper.Map<CreatedDonationCategoryResponse>(createdDonationCategory);
    }
}
