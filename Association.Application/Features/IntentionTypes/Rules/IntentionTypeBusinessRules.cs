using Association.Application.Common;
using Association.Application.Services.DonationShares;
using Association.Application.Services.IntentionTypes;
using Association.Core.Entities;
using Association.Core.Exceptions;

namespace Association.Application.Features.IntentionTypes.Rules;
public class IntentionTypeBusinessRules : BaseBusinessRules
{
    private readonly IIntentionTypeService _intentionTypeService;
    private readonly IDonationShareService _donationShareService;

    public IntentionTypeBusinessRules(IIntentionTypeService intentionTypeService, IDonationShareService donationShareService)
    {
        _intentionTypeService = intentionTypeService;
        _donationShareService = donationShareService;
    }

    private Task throwBusinessException(string erorCode, string message, string solution)
    {
        throw new BusinessException(erorCode, message, solution);
    }

    public async Task CheckIfIntentionTypeNameExists(IntentionType intentionType)
    {
        var existingIntentionType = await _intentionTypeService.AnyAsync(predicate: d => d.Name == intentionType.Name);
        if (existingIntentionType)
        {
           await throwBusinessException("IntentionTypeExists", "Bu isimde bir niyet tipi zaten mevcut.", "Farklı bir isim deneyin.");
        }
    }

    public async Task CheckIfIntentionTypeIdExists(IntentionType intentionType)
    {
        var existingIntentionType = await _intentionTypeService.AnyAsync(predicate: d => d.Id == intentionType.Id);
        if (!existingIntentionType)
        {
            await throwBusinessException("IntentionTypeNotExists", "Bu id'ye ait bir niyet tipi bulunamadı.", "Geçerli bir id girin.");
        }
    }

    public async Task CheckIfIntentionTypeHasDonationShares(IntentionType intentionType)
    {
        var existingDonationShares = await _donationShareService.AnyAsync(predicate: d => d.IntentionTypeId == intentionType.Id);
        if (existingDonationShares)
        {
            await throwBusinessException("IntentionTypeHasDonationShares", "Bu niyet tipine bağlı bağış hisseleri bulunmaktadır.", "Önce bağış hisselerini silin.");
        }
    }
}
