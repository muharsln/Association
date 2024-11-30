using Association.Application.Features.DonationOptions.Rules;
using Association.Application.Services.DonationOptions;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationOptions.Commands.Update;
public class UpdateDonationOptionCommandHandler(IDonationOptionService donationOptionService, IMapper mapper, DonationOptionBusinessRules donationOptionBusinessRules) : IRequestHandler<UpdateDonationOptionCommand, UpdatedDonationOptionResponse>
{
    public async Task<UpdatedDonationOptionResponse> Handle(UpdateDonationOptionCommand request, CancellationToken cancellationToken)
    {
        var donationOption = mapper.Map<DonationOption>(request);

        await donationOptionBusinessRules.CheckDonationOptionExistsAsync(donationOption);
        await donationOptionBusinessRules.CheckDonationOptionNameAsync(donationOption);

        donationOption = await donationOptionService.GetAsync(d => d.Id == request.Id);

        donationOption.DonationCategoryId = request.DonationCategoryId ?? donationOption.DonationCategoryId;
        donationOption.Sequence = request.Sequence ?? donationOption.Sequence;
        donationOption.Name = request.Name ?? donationOption.Name;
        donationOption.Price = request.Price ?? donationOption.Price;
        donationOption.IsActive = request.IsActive ?? donationOption.IsActive;
        donationOption.Currency = request.Currency ?? donationOption.Currency;

        await donationOptionBusinessRules.ValidateDonationCategoryExistsAsync(donationOption);

        await donationOptionService.UpdateAsync(donationOption);

        return mapper.Map<UpdatedDonationOptionResponse>(donationOption);
    }
}
