using Association.Application.Common;
using Association.Application.Services.DonationCategories;
using Association.Application.Services.DonationForms;
using Association.Application.Services.DonationGroups;
using Association.Application.Services.DonationOptions;
using Association.Core.Entities;

namespace Association.Application.Features.DonationCategories.Rules;
public class DonationCategoryBusinessRules(IDonationCategoryService donationCategoryService, IDonationGroupService donationGroupService, IDonationOptionService donationOptionService, IDonationFormService donationFormService) : BaseBusinessRules
{
    public async Task CheckIfNameExistsAsync(DonationCategory donationCategory)
    {
        var donationCategoryNameExists = await donationCategoryService.AnyAsync(predicate: d => d.Name == donationCategory.Name);

        if (donationCategoryNameExists)
        {
            await ThrowBusinessException("Bu isimde bir bağış kategorisi zaten mevcut.", "Başka bir isim giriniz.");
        }
    } 

    public async Task CheckIfIdExistsAsync(DonationCategory donationCategory)
    {
        var donationCategoryIdExists = await donationCategoryService.AnyAsync(predicate: d => d.Id == donationCategory.Id);

        if (!donationCategoryIdExists)
        {
            await ThrowBusinessException("Bu id'ye sahip bir bağış kategorisi bulunamadı.", "Geçerli bir id giriniz.");
        }
    }

    public async Task CheckIfDonationGroupExistsAsync(DonationCategory donationCategory)
    {
        var donationGroupExists = await donationGroupService.AnyAsync(predicate: d => d.Id == donationCategory.DonationGroupId);

        if (!donationGroupExists)
        {
            await ThrowBusinessException("Bu id'ye sahip bir bağış grubu bulunamadı.", "Geçerli bir bağış grubu id'si giriniz.");
        }
    }

    public async Task CheckIfDonationCategoryHasDonationFormsAsync(DonationCategory donationCategory)
    {
        var donationCategoryHasDonationForms = await donationFormService.AnyAsync(predicate: d => d.DonationCategoryId == donationCategory.Id);
        if (donationCategoryHasDonationForms)
        {
            await ThrowBusinessException("Bu bağış kategorisine bağlı bağış formu bulunmaktadır.", "Önce bağlı olduğu bağış formunu siliniz.");
        }
    }

    public async Task CheckIfDonationCategoryHasDonationOptionsAsync(DonationCategory donationCategory)
    {
        var donationCategoryHasDonationOptions = await donationOptionService.AnyAsync(predicate: d => d.DonationCategoryId == donationCategory.Id);
        if (donationCategoryHasDonationOptions)
        {
            await ThrowBusinessException("Bu bağış kategorisine bağlı bağış seçeneği bulunmaktadır.", "Önce bağlı olduğu bağış seçeneğini siliniz.");
        }
    }
}
