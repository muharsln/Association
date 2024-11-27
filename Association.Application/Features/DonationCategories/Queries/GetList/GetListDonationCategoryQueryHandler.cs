using Association.Application.Services.DonationCategories;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationCategories.Queries.GetList;
public class GetListDonationCategoryQueryHandler(IDonationCategoryService donationCategoryService, IMapper mapper) : IRequestHandler<GetListDonationCategoryQuery, ICollection<GetListDonationCategoryDto>>
{
    public async Task<ICollection<GetListDonationCategoryDto>> Handle(GetListDonationCategoryQuery request, CancellationToken cancellationToken)
    {
        var donationCategories = await donationCategoryService.GetListAsync();
        return mapper.Map<ICollection<GetListDonationCategoryDto>>(donationCategories);
    }
}
