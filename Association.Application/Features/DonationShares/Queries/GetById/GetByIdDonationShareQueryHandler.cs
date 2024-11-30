using Association.Application.Features.DonationShares.Rules;
using Association.Application.Services.DonationShares;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationShares.Queries.GetById;
public class GetByIdDonationShareQueryHandler(IDonationShareService donationShareService, IMapper mapper, DonationShareBusinessRules donationShareBusinessRules) : IRequestHandler<GetByIdDonationShareQuery, GetByIdDonationShareDto>
{
    public async Task<GetByIdDonationShareDto> Handle(GetByIdDonationShareQuery request, CancellationToken cancellationToken)
    {
        var donationShare = mapper.Map<DonationShare>(request);

        await donationShareBusinessRules.CheckDonationShareAsync(donationShare);

        donationShare = await donationShareService.GetAsync(d => d.Id == donationShare.Id);

        return mapper.Map<GetByIdDonationShareDto>(donationShare);
    }
}
