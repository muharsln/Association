using Association.Application.Features.DonationForms.Rules;
using Association.Application.Services.DonationForms;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationForms.Commands.Create;
public class CreateDonationFormCommandHandler(IDonationFormService donationFormService, IMapper mapper, DonationFormBusinessRules donationFormBusinessRules) : IRequestHandler<CreateDonationFormCommand, CreatedDonationFormResponse>
{
    public async Task<CreatedDonationFormResponse> Handle(CreateDonationFormCommand request, CancellationToken cancellationToken)
    {
        var donationForm = mapper.Map<DonationForm>(request);

        await donationFormBusinessRules.CheckDonorExistsAsync(donationForm);
        await donationFormBusinessRules.CheckDonationCategoryExistsAsync(donationForm);

        await donationFormService.AddAsync(donationForm);

        return mapper.Map<CreatedDonationFormResponse>(donationForm);
    }
}
