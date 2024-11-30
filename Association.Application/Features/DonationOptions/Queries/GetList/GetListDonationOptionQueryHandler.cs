using Association.Application.Services.DonationOptions;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationOptions.Queries.GetList;
public class GetListDonationOptionQueryHandler(IDonationOptionService donationOptionService, IMapper mapper) : IRequestHandler<GetListDonationOptionQuery, ICollection<GetListDonationOptionDto>>
{
    public async Task<ICollection<GetListDonationOptionDto>> Handle(GetListDonationOptionQuery request, CancellationToken cancellationToken)
    {
        var donationOptions = await donationOptionService.GetListAsync();

        return mapper.Map<ICollection<GetListDonationOptionDto>>(donationOptions);
    }
}
