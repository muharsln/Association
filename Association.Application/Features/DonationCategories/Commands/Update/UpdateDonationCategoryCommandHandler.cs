using Association.Application.Features.DonationCategories.Rules;
using Association.Application.Services.DonationCategories;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationCategories.Commands.Update;

public class UpdateDonationCategoryCommandHandler : IRequestHandler<UpdateDonationCategoryCommand, UpdatedDonationCategoryResponse>
{
    private readonly IDonationCategoryService _donationCategoryService;
    private readonly IMapper _mapper;
    private readonly DonationCategoryBusinessRules _donationCategoryBusinessRules;

    public UpdateDonationCategoryCommandHandler(IDonationCategoryService donationCategoryService, IMapper mapper, DonationCategoryBusinessRules donationCategoryBusinessRules)
    {
        _donationCategoryService = donationCategoryService;
        _mapper = mapper;
        _donationCategoryBusinessRules = donationCategoryBusinessRules;
    }

    public async Task<UpdatedDonationCategoryResponse> Handle(UpdateDonationCategoryCommand request, CancellationToken cancellationToken)
    {
        var donationCategory = _mapper.Map<DonationCategory>(request); 

        await _donationCategoryBusinessRules.CheckIfIdExists(donationCategory);
        await _donationCategoryBusinessRules.CheckIfNameExists(donationCategory);

        donationCategory = await _donationCategoryService.GetAsync(d => d.Id == request.Id);

        donationCategory.DonationGroupId = request.DonationGroupId ?? donationCategory.DonationGroupId;
        donationCategory.Name = request.Name ?? donationCategory.Name;
        donationCategory.IsActive = request.IsActive ?? donationCategory.IsActive;

        await _donationCategoryBusinessRules.CheckIfDonationGroupExists(donationCategory);

        await _donationCategoryService.UpdateAsync(donationCategory);

        return _mapper.Map<UpdatedDonationCategoryResponse>(donationCategory);

    }
}
