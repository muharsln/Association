using Association.Application.Features.DonationForms.Rules;
using Association.Application.Services.DonationForms;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationForms.Queries.GetById;
public class GetByIdDonationFormQueryHandler(IMapper mapper, IDonationFormService donationFormService, DonationFormBusinessRules donationFormBusinessRules) : IRequestHandler<GetByIdDonationFormQuery, GetByIdDonationFormDto>
{
    public async Task<GetByIdDonationFormDto> Handle(GetByIdDonationFormQuery request, CancellationToken cancellationToken)
    {
        var donationForm = mapper.Map<DonationForm>(request);

        await donationFormBusinessRules.CheckIdExistsAsync(donationForm);

        donationForm = await donationFormService.GetAsync(d => d.Id == donationForm.Id);

        return mapper.Map<GetByIdDonationFormDto>(donationForm);
    }
}
