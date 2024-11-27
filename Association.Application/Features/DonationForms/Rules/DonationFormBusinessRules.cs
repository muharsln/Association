using Association.Application.Common;
using Association.Application.Services.DonationCategories;
using Association.Application.Services.DonationForms;
using Association.Application.Services.DonationShares;
using Association.Application.Services.Donors;
using Association.Core.Entities;

namespace Association.Application.Features.DonationForms.Rules;
public class DonationFormBusinessRules(IDonorService donorService, IDonationCategoryService donationCategoryService, IDonationFormService donationFormService, IDonationShareService donationShareService) : BaseBusinessRules
{
    public async Task CheckIdExistsAsync(DonationForm donationForm)
    {
        var donationFormExists = await donationFormService.AnyAsync(d => d.Id == donationForm.Id);
        if (!donationFormExists)
        {
            await ThrowBusinessException("Bağış formu bulunamadı.", "Bağış formu seçimi yapmak zorunludur.");
        }
    }

    public async Task CheckDonorExistsAsync(DonationForm donationForm)
    {
        var donorExists = await donorService.AnyAsync(d => d.Id == donationForm.DonorId);

        if (!donorExists)
        {
            await ThrowBusinessException("Bağışçı bulunamadı.", "Bağışçı seçimi yapmak zorunludur.");
        }
    }

    public async Task CheckDonationCategoryExistsAsync(DonationForm donationForm)
    {
        var donationCategoryExists = await donationCategoryService.AnyAsync(d => d.Id == donationForm.DonationCategoryId);

        if (!donationCategoryExists)
        {
            await ThrowBusinessException("Bağış kategorisi bulunamadı.", "Kategori seçimi yapmak zorunludur."); 
        }
    }

    public async Task CheckHasDonationSharesAsync(DonationForm donationForm)
    {
        var donationShareExists = await donationShareService.AnyAsync(d => d.DonationFormId == donationForm.Id);
        if (donationShareExists)
        {
            await ThrowBusinessException("Bağış hisseleri bulunmaktadır.", "Bağış formunu silmeden önce lütfen bağış hisselerini siliniz.");
        }
    }
}
