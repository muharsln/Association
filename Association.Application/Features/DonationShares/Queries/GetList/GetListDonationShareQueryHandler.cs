using Association.Application.Services.DonationShares;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationShares.Queries.GetList;
public class GetListDonationShareQueryHandler(IDonationShareService donationShareService, IMapper mapper) : IRequestHandler<GetListDonationShareQuery, ICollection<GetListDonationShareDto>>
{
    public async Task<ICollection<GetListDonationShareDto>> Handle(GetListDonationShareQuery request, CancellationToken cancellationToken)
    {
        var donationShares = await donationShareService.GetListAsync();

        return mapper.Map<ICollection<GetListDonationShareDto>>(donationShares);
    }
}
