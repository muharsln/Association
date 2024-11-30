using Association.Application.Features.DonationOptions.Rules;
using Association.Application.Services.DonationOptions;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationOptions.Queries.GetById;
public class GetByIdDonationOptionQueryHandler(IDonationOptionService donationOptionService, IMapper mapper, DonationOptionBusinessRules donationOptionBusinessRules) : IRequestHandler<GetByIdDonationOptionQuery, GetByIdDonationOptionDto>
{
    public async Task<GetByIdDonationOptionDto> Handle(GetByIdDonationOptionQuery request, CancellationToken cancellationToken)
    {
        var donationOption = mapper.Map<DonationOption>(request);

        await donationOptionBusinessRules.CheckDonationOptionExistsAsync(donationOption);

        donationOption = await donationOptionService.GetAsync(d => d.Id == request.Id);

        return mapper.Map<GetByIdDonationOptionDto>(donationOption);
    }
}
