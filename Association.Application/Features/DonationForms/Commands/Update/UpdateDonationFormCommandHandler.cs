using Association.Application.Features.DonationForms.Rules;
using Association.Application.Services.DonationForms;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationForms.Commands.Update;
public class UpdateDonationFormCommandHandler(IMapper mapper, IDonationFormService donationFormService, DonationFormBusinessRules donationFormBusinessRules) : IRequestHandler<UpdateDonationFormCommand, UpdatedDonationFormResponse>
{
    public async Task<UpdatedDonationFormResponse> Handle(UpdateDonationFormCommand request, CancellationToken cancellationToken)
    {
        var donationForm = mapper.Map<DonationForm>(request);

        await donationFormBusinessRules.CheckIdExistsAsync(donationForm);

        donationForm = await donationFormService.GetAsync(d => d.Id == donationForm.Id);

        donationForm.DonorId = request.DonorId ?? donationForm.DonorId;
        donationForm.DonationCategoryId = request.DonationCategoryId ?? donationForm.DonationCategoryId;
        donationForm.TotalPrice = request.TotalPrice ?? donationForm.TotalPrice;

        await donationFormBusinessRules.CheckDonorExistsAsync(donationForm);
        await donationFormBusinessRules.CheckDonationCategoryExistsAsync(donationForm);

        await donationFormService.UpdateAsync(donationForm);

        return mapper.Map<UpdatedDonationFormResponse>(donationForm);
    }
}
