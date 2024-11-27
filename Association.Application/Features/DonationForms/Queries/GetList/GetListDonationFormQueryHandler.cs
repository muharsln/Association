using Association.Application.Services.DonationForms;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationForms.Queries.GetList;
public class GetListDonationFormQueryHandler(IMapper mapper, IDonationFormService donationFormService) : IRequestHandler<GetListDonationFormQuery, ICollection<GetListDonationFormDto>>
{
    public async Task<ICollection<GetListDonationFormDto>> Handle(GetListDonationFormQuery request, CancellationToken cancellationToken)
    {
        var donationForms = await donationFormService.GetListAsync();
        return mapper.Map<ICollection<GetListDonationFormDto>>(donationForms);
    }
}
