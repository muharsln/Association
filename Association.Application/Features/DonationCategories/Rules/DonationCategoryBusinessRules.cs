using Association.Application.Common;
using Association.Application.Services.DonationCategories;
using Association.Application.Services.DonationForms;
using Association.Application.Services.DonationGroups;
using Association.Application.Services.DonationOptions;
using Association.Core.Entities;
using Association.Core.Exceptions;

namespace Association.Application.Features.DonationCategories.Rules;
public class DonationCategoryBusinessRules : BaseBusinessRules
{
    private readonly IDonationCategoryService _donationCategoryService;
    private readonly IDonationGroupService _donationGroupService;
    private readonly IDonationOptionService _donationOptionService;
    private readonly IDonationFormService _donationFormService;

    public DonationCategoryBusinessRules(IDonationCategoryService donationCategoryService, IDonationGroupService donationGroupService, IDonationOptionService donationOptionService, IDonationFormService donationFormService)
    {
        _donationCategoryService = donationCategoryService;
        _donationGroupService = donationGroupService;
        _donationOptionService = donationOptionService;
        _donationFormService = donationFormService;
    }

    private Task throwBusinessException(string erorCode, string message, string solution)
    {
        throw new BusinessException(erorCode, message, solution);
    }

    public async Task CheckIfNameExists(DonationCategory donationCategory)
    {
        var donationCategoryNameExists = await _donationCategoryService.AnyAsync(predicate: d => d.Name == donationCategory.Name);

        if (donationCategoryNameExists)
        {
            await throwBusinessException("DonationCategoryNameExists", "Bu isimde bir bağış kategorisi zaten mevcut.", "Başka bir isim giriniz.");
        }
    } 

    public async Task CheckIfIdExists(DonationCategory donationCategory)
    {
        var donationCategoryIdExists = await _donationCategoryService.AnyAsync(predicate: d => d.Id == donationCategory.Id);

        if (!donationCategoryIdExists)
        {
            await throwBusinessException("DonationCategoryIdNotExists", "Bu id'ye sahip bir bağış kategorisi bulunamadı.", "Geçerli bir id giriniz.");
        }
    }

    public async Task CheckIfDonationGroupExists(DonationCategory donationCategory)
    {
        var donationGroupExists = await _donationGroupService.AnyAsync(predicate: d => d.Id == donationCategory.DonationGroupId);

        if (!donationGroupExists)
        {
            await throwBusinessException("DonationGroupNotExists", "Bu id'ye sahip bir bağış grubu bulunamadı.", "Geçerli bir bağış grubu id'si giriniz.");
        }
    }

    public async Task CheckIfDonationCategoryHasDonationForms(DonationCategory donationCategory)
    {
        var donationCategoryHasDonationForms = await _donationFormService.AnyAsync(predicate: d => d.DonationCategoryId == donationCategory.Id);
        if (donationCategoryHasDonationForms)
        {
            await throwBusinessException("DonationCategoryHasDonationForms", "Bu bağış kategorisine bağlı bağış formu bulunmaktadır.", "Önce bağlı olduğu bağış formunu siliniz.");
        }
    }

    public async Task CheckIfDonationCategoryHasDonationOptions(DonationCategory donationCategory)
    {
        var donationCategoryHasDonationOptions = await _donationOptionService.AnyAsync(predicate: d => d.DonationCategoryId == donationCategory.Id);
        if (donationCategoryHasDonationOptions)
        {
            await throwBusinessException("DonationCategoryHasDonationOptions", "Bu bağış kategorisine bağlı bağış seçeneği bulunmaktadır.", "Önce bağlı olduğu bağış seçeneğini siliniz.");
        }
    }
}
