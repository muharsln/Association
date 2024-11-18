using Association.Application.Repositories;
using Association.Core.Entities;
using System.Linq.Expressions;

namespace Association.Application.Services.DonationShares;
public class DonationShareManager : IDonationShareService
{
    private readonly IDonationShareRepository _donationShareRepository;

    public DonationShareManager(IDonationShareRepository donationShareRepository)
    {
        _donationShareRepository = donationShareRepository;
    }

    public async Task<DonationShare> AddAsync(DonationShare entity)
    {
        DonationShare addedDonationShare = await _donationShareRepository.AddAsync(entity);
        return addedDonationShare;
    }

    public async Task<DonationShare> DeleteAsync(DonationShare entity)
    {
        DonationShare deletedDonationShare = await _donationShareRepository.DeleteAsync(entity);
        return deletedDonationShare;
    }

    public async Task<DonationShare> GetAsync(Expression<Func<DonationShare, bool>> predicate)
    {
        DonationShare? donationShare = await _donationShareRepository.GetAsync(predicate);
        return donationShare;
    }

    public async Task<ICollection<DonationShare>> GetListAsync(Expression<Func<DonationShare, bool>>? predicate = null)
    {
        ICollection<DonationShare> donationShares = await _donationShareRepository.GetListAsync(predicate);
        return donationShares;
    }

    public async Task<DonationShare> UpdateAsync(DonationShare entity)
    {
        DonationShare updatedDonationShare = await _donationShareRepository.UpdateAsync(entity);
        return updatedDonationShare;
    }
}

