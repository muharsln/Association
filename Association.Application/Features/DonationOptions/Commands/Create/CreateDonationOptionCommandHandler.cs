using Association.Application.Features.DonationOptions.Rules;
using Association.Application.Services.DonationOptions;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationOptions.Commands.Create;
public class CreateDonationOptionCommandHandler(IDonationOptionService donationOptionService, IMapper mapper, DonationOptionBusinessRules donationOptionBusinessRules) : IRequestHandler<CreateDonationOptionCommand, CreatedDonationOptionResponse>
{
    public async Task<CreatedDonationOptionResponse> Handle(CreateDonationOptionCommand request, CancellationToken cancellationToken)
    {
        var donationOption  = mapper.Map<DonationOption>(request);

        await donationOptionBusinessRules.CheckDonationOptionNameAsync(donationOption);

        await donationOptionBusinessRules.ValidateDonationCategoryExistsAsync(donationOption);

        await donationOptionService.AddAsync(donationOption);

        return mapper.Map<CreatedDonationOptionResponse>(donationOption);
    }
}
