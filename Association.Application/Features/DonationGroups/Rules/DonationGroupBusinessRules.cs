using Association.Application.Common;
using Association.Application.Services.DonationCategories;
using Association.Application.Services.DonationGroups;
using Association.Core.Entities;

namespace Association.Application.Features.DonationGroups.Rules;

public class DonationGroupBusinessRules(IDonationGroupService donationGroupService, IDonationCategoryService donationCategoryService) : BaseBusinessRules
{
    public async Task CheckIfDonationGroupNameExistsAsync(DonationGroup donationGroup)
    {
        var existingDonationGroup = await donationGroupService.AnyAsync(predicate: d => d.Name == donationGroup.Name);
        if (existingDonationGroup)
        {
            await ThrowBusinessException("Bağış grubu zaten mevcut", "Lütfen farklı bir isim verin");
        }
    }

    public async Task CheckIfDonationGroupIdExistsAsync(DonationGroup donationGroup)
    {
        var donationGroupExists = await donationGroupService.AnyAsync(predicate: d => d.Id == donationGroup.Id);
        if (!donationGroupExists)
        {
            await ThrowBusinessException("Bağış grubu bulunamadı", "Lütfen geçerli bir bağış grubu seçin");
        }
    }
    public async Task CheckIfDonationGroupHasDonationCategoriesAsync(DonationGroup donationGroup)
    {
        var donationCategoriesExist = await donationCategoryService.AnyAsync(predicate: d => d.DonationGroupId == donationGroup.Id);

        if (donationCategoriesExist)
        {
            await ThrowBusinessException("Bağış grubuna ait kategori bulunmaktadır", "Bağış grubunu silmek için önce kategorileri silin");
        }
    }
}
