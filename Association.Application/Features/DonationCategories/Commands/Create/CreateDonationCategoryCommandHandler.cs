using Association.Application.Features.DonationCategories.Rules;
using Association.Application.Services.DonationCategories;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationCategories.Commands.Create;
public class CreateDonationCategoryCommandHandler(IDonationCategoryService donationCategoryService, IMapper mapper, DonationCategoryBusinessRules donationCategoryBusinessRules) : IRequestHandler<CreateDonationCategoryCommand, CreatedDonationCategoryResponse>
{
    public async Task<CreatedDonationCategoryResponse> Handle(CreateDonationCategoryCommand request, CancellationToken cancellationToken)
    {
        var donationCategory = mapper.Map<DonationCategory>(request);
        await donationCategoryBusinessRules.CheckIfNameExistsAsync(donationCategory);
        await donationCategoryBusinessRules.CheckIfDonationGroupExistsAsync(donationCategory);
        var createdDonationCategory = await donationCategoryService.AddAsync(donationCategory);
        return mapper.Map<CreatedDonationCategoryResponse>(createdDonationCategory);
    }
}
