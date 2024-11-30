using Association.Application.Features.DonationShares.Rules;
using Association.Application.Services.DonationOptions;
using Association.Application.Services.DonationShares;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationShares.Commands.Create;
public class CreateDonationShareCommandHandler(IDonationShareService donationShareService, IDonationOptionService donationOptionService, IMapper mapper, DonationShareBusinessRules donationShareBusinessRules) : IRequestHandler<CreateDonationShareCommand, CreatedDonationShareResponse>
{
    public async Task<CreatedDonationShareResponse> Handle(CreateDonationShareCommand request, CancellationToken cancellationToken)
    {
        var donationShare = mapper.Map<DonationShare>(request);

        await donationShareBusinessRules.CheckDonationFormAsync(donationShare);
        await donationShareBusinessRules.CheckDonationOptionAsync(donationShare);
        await donationShareBusinessRules.CheckIntentionTypeAsync(donationShare);

        SetShareAmount(donationShare);

        await donationShareService.AddAsync(donationShare);

        return mapper.Map<CreatedDonationShareResponse>(donationShare);
    }

    private void SetShareAmount(DonationShare donationShare)
    {
        if (donationShare.ShareAmount <= 0)
        {
            var donationOption = donationOptionService.GetAsync(d => d.Id == donationShare.DonationOptionId).Result;
            donationShare.ShareAmount = donationOption.Price;
        }
    }
}
