using Association.Application.Repositories;
using Association.Core.Entities;
using System.Linq.Expressions;

// Bu servisler, uygulama katmanında kullanılacak olan repository'lerle çalışır.
// Repository'ler, veritabanı işlemlerini gerçekleştiren sınıflardır.

namespace Association.Application.Services.DonationForms;

public class DonationFormManager : IDonationFormService
{
    private readonly IDonationFormRepository _donationFormRepository;

    public DonationFormManager(IDonationFormRepository donationFormRepository)
    {
        _donationFormRepository = donationFormRepository;
    }

    public async Task<DonationForm> AddAsync(DonationForm entity)
    {
        DonationForm addedDonationForm = await _donationFormRepository.AddAsync(entity);
        return addedDonationForm;
    }

    public async Task<DonationForm> DeleteAsync(DonationForm entity)
    {
        DonationForm deletedDonationForm = await _donationFormRepository.DeleteAsync(entity);
        return deletedDonationForm;
    }

    public async Task<DonationForm> GetAsync(Expression<Func<DonationForm, bool>> predicate)
    {
        DonationForm? donationForm = await _donationFormRepository.GetAsync(predicate);
        return donationForm;
    }

    public async Task<ICollection<DonationForm>> GetListAsync(Expression<Func<DonationForm, bool>>? predicate = null)
    {
        ICollection<DonationForm> donationForms = await _donationFormRepository.GetListAsync(predicate);
        return donationForms;
    }

    public async Task<DonationForm> UpdateAsync(DonationForm entity)
    {
        DonationForm updatedDonationForm = await _donationFormRepository.UpdateAsync(entity);
        return updatedDonationForm;
    }
}