using Association.Application.Services.DonationCategories;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationCategories.Queries.GetList;

public class GetListDonationCategoryQueryHandler : IRequestHandler<GetListDonationCategoryQuery, ICollection<GetListDonationCategoryDto>>
{
    private readonly IDonationCategoryService _donationCategoryService;
    private readonly IMapper _mapper;

    public GetListDonationCategoryQueryHandler(IDonationCategoryService donationCategoryService, IMapper mapper)
    {
        _donationCategoryService = donationCategoryService;
        _mapper = mapper;
    }

    public async Task<ICollection<GetListDonationCategoryDto>> Handle(GetListDonationCategoryQuery request, CancellationToken cancellationToken)
    {
        var donationCategories = await _donationCategoryService.GetListAsync();
        return _mapper.Map<ICollection<GetListDonationCategoryDto>>(donationCategories);
    }
}
