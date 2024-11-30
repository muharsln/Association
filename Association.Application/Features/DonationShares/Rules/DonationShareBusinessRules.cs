using Association.Application.Common;
using Association.Application.Services.DonationForms;
using Association.Application.Services.DonationOptions;
using Association.Application.Services.DonationShares;
using Association.Application.Services.IntentionTypes;
using Association.Core.Entities;

namespace Association.Application.Features.DonationShares.Rules;
public class DonationShareBusinessRules(IDonationShareService donationShareService, IDonationFormService donationFormService, IDonationOptionService donationOptionService, IIntentionTypeService intentionTypeService) : BaseBusinessRules
{
    public async Task CheckDonationFormAsync(DonationShare donationShare)
    {
        var donationForm = await donationFormService.AnyAsync(d => d.Id == donationShare.DonationFormId);
        if (!donationForm)
        {
            await ThrowBusinessException("Bağış Formu Bulunamadı", "Lütfen bağış formu id değerlerini kontrol ediniz.");
        }
    }

    public async Task CheckDonationOptionAsync(DonationShare donationShare)
    {
        var donationOption = await donationOptionService.AnyAsync(d => d.Id == donationShare.DonationOptionId);
        if (!donationOption)
        {
            await ThrowBusinessException("Bağış Seçeneği Bulunamadı", "Lütfen bağış seçeneği id değerlerini kontrol ediniz.");
        }
    }

    public async Task CheckIntentionTypeAsync(DonationShare donationShare)
    {
        var intentionType = await intentionTypeService.AnyAsync(d => d.Id == donationShare.IntentionTypeId);
        if (!intentionType)
        {
            await ThrowBusinessException("Bağış niyeti Bulunamadı", "Lütfen bağış niyeti id değerlerini kontrol ediniz.");
        }
    }

    public async Task CheckDonationShareAsync(DonationShare donationShare)
    {
        var donationShareExist = await donationShareService.AnyAsync(d => d.Id == donationShare.Id);
        if (!donationShareExist)
        {
            await ThrowBusinessException("Bağış hissesi Bulunamadı", "Lütfen bağış hissesi id değerlerini kontrol ediniz.");
        }
    }
}
