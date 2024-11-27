using Association.Application.Common;
using Association.Application.Services.DonationCategories;
using Association.Application.Services.DonationOptions;
using Association.Application.Services.DonationShares;
using Association.Core.Entities;

namespace Association.Application.Features.DonationOptions.Rules;
public class DonationOptionBusinessRules(IDonationOptionService donationOptionService, IDonationCategoryService donationCategoryService, IDonationShareService donationShareService) : BaseBusinessRules
{
    public async Task CheckDonationOptionNameAsync(DonationOption donationOption)
    {
        var existingDonationOption = await donationOptionService.AnyAsync(predicate: d => d.Name == donationOption.Name && d.DonationCategoryId == donationOption.DonationCategoryId);

        if (existingDonationOption)
        {
            await ThrowBusinessException("Bu isimde bir bağış seçeneği zaten mevcut.", "Başka bir isim giriniz.");
        }
    }

    public async Task ValidateDonationCategoryExistsAsync(DonationOption donationOption)
    {
        var donationCategoryExists = await donationCategoryService.AnyAsync(predicate: d => d.Id == donationOption.DonationCategoryId);

        if (!donationCategoryExists)
        {
            await ThrowBusinessException("Bağış kategorisi bulunamadı.", "Geçerli bir bağış kategorisi seçiniz.");
        }
    }

    public async Task CheckDonationOptionExistsAsync(DonationOption donationOption)
    {
        var donationOptionExists = await donationOptionService.AnyAsync(predicate: d => d.Id == donationOption.Id);
        if (!donationOptionExists)
        {
            await ThrowBusinessException("Bağış seçeneği bulunamadı.", "Geçerli bir bağış seçeneği seçiniz.");
        }
    }

    public async Task CheckDonationOptionHasDonationSharesAsync(DonationOption donationOption)
    {
        var donationSharesExists = await donationShareService.AnyAsync(predicate: d => d.DonationOptionId == donationOption.Id);
        if (donationSharesExists)
        {
            await ThrowBusinessException("Bu bağış seçeneğine ait bağış hisseleri bulunmaktadır.", "Bağış seçeneğini silebilmek için önce bağış hisselerini siliniz.");
        }
    }
}
