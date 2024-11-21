using Association.Application.Common;
using Association.Application.Services.DonationCategories;
using Association.Application.Services.DonationGroups;
using Association.Core.Entities;
using Association.Core.Exceptions;

namespace Association.Application.Features.DonationGroups.Rules;

public class DonationGroupBusinessRules : BaseBusinessRules
{
    private readonly IDonationGroupService _donationGroupService;
    private readonly IDonationCategoryService _donationCategoryService;

    public DonationGroupBusinessRules(IDonationGroupService donationGroupService, IDonationCategoryService donationCategoryService)
    {
        _donationGroupService = donationGroupService;
        _donationCategoryService = donationCategoryService;
    }

    private Task throwBusinessException(string erorCode, string message, string solution)
    {
        throw new BusinessException(erorCode, message, solution);
    }

    public async Task CheckIfDonationGroupNameExists(DonationGroup donationGroup)
    {
        var existingDonationGroup = await _donationGroupService.AnyAsync(predicate: d => d.Name == donationGroup.Name);
        if (existingDonationGroup)
        {
            await throwBusinessException("DonationGroupExists", "Bağış grubu zaten mevcut", "Lütfen farklı bir isim verin");
        }
    }

    public async Task CheckIfDonationGroupIdExists(DonationGroup donationGroup)
    {
        var donationGroupExists = await _donationGroupService.AnyAsync(predicate: d => d.Id == donationGroup.Id);
        if (!donationGroupExists)
        {
            await throwBusinessException("DonationGroupNotFound", "Bağış grubu bulunamadı", "Lütfen geçerli bir bağış grubu seçin");
        }
    }
    public async Task CheckIfDonationGroupHasDonationCategories(DonationGroup donationGroup)
    {
        var donationCategoriesExist = await _donationCategoryService.AnyAsync(predicate: d => d.DonationGroupId == donationGroup.Id);

        if (donationCategoriesExist)
        {
            await throwBusinessException("DonationCategoriesExist", "Bağış grubuna ait kategori bulunmaktadır", "Bağış grubunu silmek için önce kategorileri silin");
        }
    }
}
