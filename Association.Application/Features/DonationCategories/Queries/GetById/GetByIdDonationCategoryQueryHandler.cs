using Association.Application.Features.DonationCategories.Rules;
using Association.Application.Services.DonationCategories;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationCategories.Queries.GetById;
public class GetByIdDonationCategoryQueryHandler(IDonationCategoryService donationCategoryService, IMapper mapper, DonationCategoryBusinessRules donationCategoryBusinessRules) : IRequestHandler<GetByIdDonationCategoryQuery, GetByIdDonationCategoryDto>
{
    public async Task<GetByIdDonationCategoryDto> Handle(GetByIdDonationCategoryQuery request, CancellationToken cancellationToken)
    {
        var donationCategory = mapper.Map<DonationCategory>(request);
        await donationCategoryBusinessRules.CheckIfIdExistsAsync(donationCategory);

        donationCategory = await donationCategoryService.GetAsync(d => d.Id == request.Id);

        return mapper.Map<GetByIdDonationCategoryDto>(donationCategory);
    }
}
