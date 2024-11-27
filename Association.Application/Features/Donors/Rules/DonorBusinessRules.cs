using Association.Application.Common;
using Association.Application.Services.DonationForms;
using Association.Application.Services.Donors;
using Association.Core.Entities;

namespace Association.Application.Features.Donors.Rules;

public class DonorBusinessRules(IDonorService donorService, IDonationFormService donationFormService) : BaseBusinessRules
{
    public async Task CheckIfEmailExistsAsync(Donor donor)
    {
        var donorByEmail = await donorService.AnyAsync(predicate: d => d.Email == donor.Email);

        if (donorByEmail)
        {
            await ThrowBusinessException("Bu e-postaya sahip bağışçı zaten mevcut", "Lütfen farklı bir e-posta adresi giriniz");
        }
    }

    public async Task CheckIfDonorExistsAsync(Donor donor)
    {
        var donorExists = await donorService.AnyAsync(predicate: d => d.Id == donor.Id);
        if (!donorExists)
        {
            await ThrowBusinessException("Bu bağışçı mevcut değildir.", "");
        }
    }

    public async Task CheckIfDonorHasDonationFormsAsync(Donor donor)
    {
        var donorHasDonationForms = await donationFormService.AnyAsync(predicate: d => d.DonorId == donor.Id);
        if (donorHasDonationForms)
        {
            await ThrowBusinessException("Bu bağışçının bağış formu bulunmaktadır.", "Bağışçının bağış formlarını silmeden önce bağış formlarını siliniz.");
        }
    }
}
