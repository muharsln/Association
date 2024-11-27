using Association.Application.Common;
using Association.Application.Services.DonationShares;
using Association.Application.Services.IntentionTypes;
using Association.Core.Entities;

namespace Association.Application.Features.IntentionTypes.Rules;
public class IntentionTypeBusinessRules(IIntentionTypeService intentionTypeService, IDonationShareService donationShareService) : BaseBusinessRules
{
    public async Task CheckIfIntentionTypeNameExistsAsync(IntentionType intentionType)
    {
        var existingIntentionType = await intentionTypeService.AnyAsync(predicate: d => d.Name == intentionType.Name);
        if (existingIntentionType)
        {
           await ThrowBusinessException("Bu isimde bir niyet tipi zaten mevcut.", "Farklı bir isim deneyin.");
        }
    }

    public async Task CheckIfIntentionTypeIdExistsAsync(IntentionType intentionType)
    {
        var existingIntentionType = await intentionTypeService.AnyAsync(predicate: d => d.Id == intentionType.Id);
        if (!existingIntentionType)
        {
            await ThrowBusinessException("Bu id'ye ait bir niyet tipi bulunamadı.", "Geçerli bir id girin.");
        }
    }

    public async Task CheckIfIntentionTypeHasDonationSharesAsync(IntentionType intentionType)
    {
        var existingDonationShares = await donationShareService.AnyAsync(predicate: d => d.IntentionTypeId == intentionType.Id);
        if (existingDonationShares)
        {
            await ThrowBusinessException("Bu niyet tipine bağlı bağış hisseleri bulunmaktadır.", "Önce bağış hisselerini silin.");
        }
    }
}
