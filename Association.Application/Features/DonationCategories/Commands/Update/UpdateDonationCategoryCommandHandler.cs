using Association.Application.Features.DonationCategories.Rules;
using Association.Application.Services.DonationCategories;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationCategories.Commands.Update;
public class UpdateDonationCategoryCommandHandler(IDonationCategoryService donationCategoryService, IMapper mapper, DonationCategoryBusinessRules donationCategoryBusinessRules) : IRequestHandler<UpdateDonationCategoryCommand, UpdatedDonationCategoryResponse>
{
    public async Task<UpdatedDonationCategoryResponse> Handle(UpdateDonationCategoryCommand request, CancellationToken cancellationToken)
    {
        var donationCategory = mapper.Map<DonationCategory>(request); 

        await donationCategoryBusinessRules.CheckIfIdExistsAsync(donationCategory);
        await donationCategoryBusinessRules.CheckIfNameExistsAsync(donationCategory);

        donationCategory = await donationCategoryService.GetAsync(d => d.Id == request.Id);

        donationCategory.DonationGroupId = request.DonationGroupId ?? donationCategory.DonationGroupId;
        donationCategory.Name = request.Name ?? donationCategory.Name;
        donationCategory.IsActive = request.IsActive ?? donationCategory.IsActive;

        await donationCategoryBusinessRules.CheckIfDonationGroupExistsAsync(donationCategory);

        await donationCategoryService.UpdateAsync(donationCategory);

        return mapper.Map<UpdatedDonationCategoryResponse>(donationCategory);
    }
}
