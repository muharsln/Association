using Association.Application.Features.DonationShares.Rules;
using Association.Application.Services.DonationShares;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationShares.Commands.Update;
public class UpdateDonationShareCommandHandler(IDonationShareService donationShareService, IMapper mapper, DonationShareBusinessRules donationShareBusinessRules) : IRequestHandler<UpdateDonationShareCommand, UpdatedDonationShareResponse>
{

    public async Task<UpdatedDonationShareResponse> Handle(UpdateDonationShareCommand request, CancellationToken cancellationToken)
    {
        var donationShare = mapper.Map<DonationShare>(request);

        await donationShareBusinessRules.CheckDonationShareAsync(donationShare);

        donationShare = await donationShareService.GetAsync(d => d.Id == donationShare.Id);

        donationShare.DonationFormId = request.DonationFormId ?? donationShare.DonationFormId;
        donationShare.DonationOptionId = request.DonationOptionId ?? donationShare.DonationOptionId;
        donationShare.IntentionTypeId = request.IntentionTypeId ?? donationShare.IntentionTypeId;
        donationShare.FirstName = request.FirstName ?? donationShare.FirstName;
        donationShare.LastName = request.LastName ?? donationShare.LastName;
        donationShare.Phone = request.Phone ?? donationShare.Phone;
        donationShare.ShareAmount = request.ShareAmount ?? donationShare.ShareAmount;

        await donationShareBusinessRules.CheckDonationFormAsync(donationShare);
        await donationShareBusinessRules.CheckDonationOptionAsync(donationShare);
        await donationShareBusinessRules.CheckIntentionTypeAsync(donationShare);

        await donationShareService.UpdateAsync(donationShare);

        return mapper.Map<UpdatedDonationShareResponse>(donationShare);
    }
}
