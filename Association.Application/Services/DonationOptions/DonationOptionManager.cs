using Association.Application.Repositories;
using Association.Core.Entities;
using System.Linq.Expressions;

// Bu servisler, uygulama katmanında kullanılacak olan repository'lerle çalışır.
// Repository'ler, veritabanı işlemlerini gerçekleştiren sınıflardır.

namespace Association.Application.Services.DonationOptions;

public class DonationOptionManager : IDonationOptionService
{
    private readonly IDonationOptionRepository _donationOptionRepository;

    public DonationOptionManager(IDonationOptionRepository donationOptionRepository)
    {
        _donationOptionRepository = donationOptionRepository;
    }

    public async Task<DonationOption> AddAsync(DonationOption entity)
    {
        DonationOption addedDonationOption = await _donationOptionRepository.AddAsync(entity);
        return addedDonationOption;
    }

    public async Task<DonationOption> DeleteAsync(DonationOption entity)
    {
        DonationOption deletedDonationOption = await _donationOptionRepository.DeleteAsync(entity);
        return deletedDonationOption;
    }

    public async Task<DonationOption> GetAsync(Expression<Func<DonationOption, bool>> predicate)
    {
        DonationOption? donationOption = await _donationOptionRepository.GetAsync(predicate);
        return donationOption;
    }

    public async Task<ICollection<DonationOption>> GetListAsync(Expression<Func<DonationOption, bool>>? predicate = null)
    {
        ICollection<DonationOption> donationOptions = await _donationOptionRepository.GetListAsync(predicate);
        return donationOptions;
    }

    public async Task<DonationOption> UpdateAsync(DonationOption entity)
    {
        DonationOption updatedDonationOption = await _donationOptionRepository.UpdateAsync(entity);
        return updatedDonationOption;
    }
}
