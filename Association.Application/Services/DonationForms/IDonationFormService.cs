using Association.Application.Services.Donors;
using Association.Core.Entities;
using System.Linq.Expressions;

// Bu servisler, uygulama katmanında kullanılacak olan repository'lerle çalışır.
// Repository'ler, veritabanı işlemlerini gerçekleştiren sınıflardır.

namespace Association.Application.Services.DonationForms;

public interface IDonationFormService
{
    Task<DonationForm> GetAsync(
    Expression<Func<DonationForm, bool>> predicate);

    Task<ICollection<DonationForm>> GetListAsync(
        Expression<Func<DonationForm, bool>>? predicate = null);

    Task<DonationForm> AddAsync(DonationForm entity);
    Task<DonationForm> UpdateAsync(DonationForm entity);
    Task<DonationForm> DeleteAsync(DonationForm entity);
}