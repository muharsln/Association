using Association.Core.Entities;
using System.Linq.Expressions;

// Bu servisler, uygulama katmanında kullanılacak olan repository'lerle çalışır.
// Repository'ler, veritabanı işlemlerini gerçekleştiren sınıflardır.

namespace Association.Application.Services.DonationShares;

public interface IDonationShareService
{
    Task<DonationShare> GetAsync(
    Expression<Func<DonationShare, bool>> predicate);

    Task<ICollection<DonationShare>> GetListAsync(
        Expression<Func<DonationShare, bool>>? predicate = null);

    Task<DonationShare> AddAsync(DonationShare entity);
    Task<DonationShare> UpdateAsync(DonationShare entity);
    Task<DonationShare> DeleteAsync(DonationShare entity);
}
