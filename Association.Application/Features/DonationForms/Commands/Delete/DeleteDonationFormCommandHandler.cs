using Association.Application.Features.DonationForms.Rules;
using Association.Application.Services.DonationForms;
using Association.Core.Entities;
using AutoMapper;
using MediatR;

namespace Association.Application.Features.DonationForms.Commands.Delete;
public class DeleteDonationFormCommandHandler(IDonationFormService donationFormService, IMapper mapper, DonationFormBusinessRules donationFormBusinessRules) : IRequestHandler<DeleteDonationFormCommand, DeletedDonationFormResponse>
{
    public async Task<DeletedDonationFormResponse> Handle(DeleteDonationFormCommand request, CancellationToken cancellationToken)
    {
        var donationForm = mapper.Map<DonationForm>(request);

        await donationFormBusinessRules.CheckIdExistsAsync(donationForm);
        await donationFormBusinessRules.CheckHasDonationSharesAsync(donationForm);
    
        await donationFormService.DeleteAsync(donationForm);

        return mapper.Map<DeletedDonationFormResponse>(donationForm);
    }
}
