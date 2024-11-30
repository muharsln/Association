using Association.Application.Repositories;
using Association.Core.Entities;
using System.Linq.Expressions;

// Bu servisler, uygulama katmanında kullanılacak olan repository'lerle çalışır.
// Repository'ler, veritabanı işlemlerini gerçekleştiren sınıflardır.

namespace Association.Application.Services.DonationGroups;

public class DonationGroupManager : IDonationGroupService
{
    private readonly IDonationGroupRepository _donationGroupRepository;

    public DonationGroupManager(IDonationGroupRepository donationGroupRepository)
    {
        _donationGroupRepository = donationGroupRepository;
    }

    public async Task<DonationGroup> AddAsync(DonationGroup entity)
    {
        DonationGroup addedDonationGroup = await _donationGroupRepository.AddAsync(entity);
        return addedDonationGroup;
    }

    public async Task<bool> AnyAsync(Expression<Func<DonationGroup, bool>> predicate)
    {
        var result = await _donationGroupRepository.AnyAsync(predicate);
        return result;
    }

    public async Task<DonationGroup> DeleteAsync(DonationGroup entity)
    {
        DonationGroup deletedDonationGroup = await _donationGroupRepository.DeleteAsync(entity);
        return deletedDonationGroup;
    }

    public async Task<DonationGroup> GetAsync(Expression<Func<DonationGroup, bool>> predicate)
    {
        DonationGroup? donationGroup = await _donationGroupRepository.GetAsync(predicate);
        return donationGroup;
    }

    public async Task<ICollection<DonationGroup>> GetListAsync(Expression<Func<DonationGroup, bool>>? predicate = null)
    {
        ICollection<DonationGroup> donationGroups = await _donationGroupRepository.GetListAsync(predicate);
        return donationGroups;
    }

    public async Task<DonationGroup> UpdateAsync(DonationGroup entity)
    {
        DonationGroup updatedDonationGroup = await _donationGroupRepository.UpdateAsync(entity);
        return updatedDonationGroup;
    }
}