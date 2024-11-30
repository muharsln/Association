using Association.Application.Features.DonationCategories.Rules;
using Association.Application.Services.DonationCategories;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationCategories.Commands.Delete;
public class DeleteDonationCategoryCommandHandler(IDonationCategoryService donationCategoryService, IMapper mapper, DonationCategoryBusinessRules donationCategoryBusinessRules) : IRequestHandler<DeleteDonationCategoryCommand, DeletedDonationCategoryResponse>
{
    public async Task<DeletedDonationCategoryResponse> Handle(DeleteDonationCategoryCommand request, CancellationToken cancellationToken)
    {
        var donationCategory = mapper.Map<DonationCategory>(request);

        await donationCategoryBusinessRules.CheckIfIdExistsAsync(donationCategory);
        await donationCategoryBusinessRules.CheckIfDonationCategoryHasDonationFormsAsync(donationCategory);
        await donationCategoryBusinessRules.CheckIfDonationCategoryHasDonationOptionsAsync(donationCategory);

        await donationCategoryService.DeleteAsync(donationCategory);

        return mapper.Map<DeletedDonationCategoryResponse>(donationCategory);
    }
}
