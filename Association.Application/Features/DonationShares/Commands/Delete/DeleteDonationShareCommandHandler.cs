using Association.Application.Features.DonationShares.Rules;
using Association.Application.Services.DonationShares;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationShares.Commands.Delete;
public class DeleteDonationShareCommandHandler(IDonationShareService donationShareService, IMapper mapper, DonationShareBusinessRules donationShareBusinessRules) : IRequestHandler<DeleteDonationShareCommand, DeletedDonationShareResponse>
{
    public async Task<DeletedDonationShareResponse> Handle(DeleteDonationShareCommand request, CancellationToken cancellationToken)
    {
        var donationShare = mapper.Map<DonationShare>(request);

        await donationShareBusinessRules.CheckDonationShareAsync(donationShare);

        await donationShareService.DeleteAsync(donationShare);

        return mapper.Map<DeletedDonationShareResponse>(donationShare);
    }
}
