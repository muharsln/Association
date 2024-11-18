using Association.Core.Entities;
using System.Linq.Expressions;

// Bu servisler, uygulama katmanında kullanılacak olan repository'lerle çalışır.
// Repository'ler, veritabanı işlemlerini gerçekleştiren sınıflardır.

namespace Association.Application.Services.DonationOptions;

public interface IDonationOptionService
{
    Task<DonationOption> GetAsync(
    Expression<Func<DonationOption, bool>> predicate);

    Task<ICollection<DonationOption>> GetListAsync(
        Expression<Func<DonationOption, bool>>? predicate = null);

    Task<DonationOption> AddAsync(DonationOption entity);
    Task<DonationOption> UpdateAsync(DonationOption entity);
    Task<DonationOption> DeleteAsync(DonationOption entity);
}
