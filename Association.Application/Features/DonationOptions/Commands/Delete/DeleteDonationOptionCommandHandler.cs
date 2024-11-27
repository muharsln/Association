using Association.Application.Features.DonationOptions.Rules;
using Association.Application.Services.DonationOptions;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationOptions.Commands.Delete;
public class DeleteDonationOptionCommandHandler(IDonationOptionService donationOptionService, IMapper mapper, DonationOptionBusinessRules donationOptionBusinessRules) : IRequestHandler<DeleteDonationOptionCommand, DeletedDonationOptionResponse>
{
    public async Task<DeletedDonationOptionResponse> Handle(DeleteDonationOptionCommand request, CancellationToken cancellationToken)
    {
        var donationOption = mapper.Map<DonationOption>(request);

        await donationOptionBusinessRules.CheckDonationOptionExistsAsync(donationOption);

        await donationOptionBusinessRules.CheckDonationOptionHasDonationSharesAsync(donationOption);

        await donationOptionService.DeleteAsync(donationOption);

        return mapper.Map<DeletedDonationOptionResponse>(donationOption);
    }
}
