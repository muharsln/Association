using Association.Application.Common;
using Association.Application.Services.DonationForms;
using Association.Application.Services.Donors;
using Association.Core.Entities;
using Association.Core.Exceptions;

namespace Association.Application.Features.Donors.Rules;

public class DonorBusinessRules : BaseBusinessRules
{
    private readonly IDonorService _donorService;
    private readonly IDonationFormService _donationFormService;

    public DonorBusinessRules(IDonorService donorService, IDonationFormService donationFormService)
    {
        _donorService = donorService;
        _donationFormService = donationFormService;
    }

    private Task throwBusinessException(string erorCode, string message, string solution)
    {
        throw new BusinessException(erorCode, message, solution);
    }

    public async Task CheckIfEmailExists(Donor donor)
    {
        var donorByEmail = await _donorService.AnyAsync(predicate: d => d.Email == donor.Email);

        if (donorByEmail)
        {
            await throwBusinessException("DonorEmailExists", "Bu e-postaya sahip bağışçı zaten mevcut", "Lütfen farklı bir e-posta adresi giriniz");
        }
    }

    public async Task CheckIfDonorExists(Donor donor)
    {
        var donorExists = await _donorService.AnyAsync(predicate: d => d.Id == donor.Id);
        if (!donorExists)
        {
            await throwBusinessException("DonorExists", "Bu bağışçı mevcut değildir.", "");
        }
    }

    public async Task CheckIfDonorHasDonationForms(Donor donor)
    {
        var donorHasDonationForms = await _donationFormService.AnyAsync(predicate: d => d.DonorId == donor.Id);
        if (donorHasDonationForms)
        {
            await throwBusinessException("DonorHasDonationForms", "Bu bağışçının bağış formu bulunmaktadır.", "Bağışçının bağış formlarını silmeden önce bağış formlarını siliniz.");
        }
    }
}
