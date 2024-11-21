using Association.Application.Features.DonationCategories.Rules;
using Association.Application.Services.DonationCategories;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationCategories.Queries.GetById;

public class GetByIdDonationCategoryQueryHandler : IRequestHandler<GetByIdDonationCategoryQuery, GetByIdDonationCategoryDto>
{
    private readonly IDonationCategoryService _donationCategoryService;
    private readonly IMapper _mapper;
    private readonly DonationCategoryBusinessRules _donationCategoryBusinessRules;

    public GetByIdDonationCategoryQueryHandler(IDonationCategoryService donationCategoryService, IMapper mapper, DonationCategoryBusinessRules donationCategoryBusinessRules)
    {
        _donationCategoryService = donationCategoryService;
        _mapper = mapper;
        _donationCategoryBusinessRules = donationCategoryBusinessRules;
    }

    public async Task<GetByIdDonationCategoryDto> Handle(GetByIdDonationCategoryQuery request, CancellationToken cancellationToken)
    {
        var donationCategory = _mapper.Map<DonationCategory>(request);
        await _donationCategoryBusinessRules.CheckIfIdExists(donationCategory);

        donationCategory = await _donationCategoryService.GetAsync(d => d.Id == request.Id);

        return _mapper.Map<GetByIdDonationCategoryDto>(donationCategory);
    }
}
