using Association.Application.Repositories;
using Association.Core.Entities;
using System.Linq.Expressions;

namespace Association.Application.Services.DonationCategories;

public class DonationCategoryManager : IDonationCategoryService
{
    private readonly IDonationCategoryRepository _donationCategoryRepository;

    public DonationCategoryManager(IDonationCategoryRepository donationCategoryRepository)
    {
        _donationCategoryRepository = donationCategoryRepository;
    }

    public async Task<DonationCategory> AddAsync(DonationCategory entity)
    {
        DonationCategory addedDonationCategory = await _donationCategoryRepository.AddAsync(entity);
        return addedDonationCategory;
    }

    public async Task<DonationCategory> DeleteAsync(DonationCategory entity)
    {
        DonationCategory deletedDonationCategory = await _donationCategoryRepository.DeleteAsync(entity);
        return deletedDonationCategory;
    }

    public async Task<DonationCategory> GetAsync(Expression<Func<DonationCategory, bool>> predicate)
    {
        DonationCategory? donationCategory = await _donationCategoryRepository.GetAsync(predicate);
        return donationCategory;
    }

    public async Task<ICollection<DonationCategory>> GetListAsync(Expression<Func<DonationCategory, bool>>? predicate = null)
    {
        ICollection<DonationCategory> donationCategories = await _donationCategoryRepository.GetListAsync(predicate);
        return donationCategories;
    }

    public async Task<DonationCategory> UpdateAsync(DonationCategory entity)
    {
        DonationCategory updatedDonationCategory = await _donationCategoryRepository.UpdateAsync(entity);
        return updatedDonationCategory;
    }
}
