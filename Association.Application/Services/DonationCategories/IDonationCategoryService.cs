using Association.Core.Entities;
using System.Linq.Expressions;

// Bu servisler, uygulama katmanında kullanılacak olan repository'lerle çalışır.
// Repository'ler, veritabanı işlemlerini gerçekleştiren sınıflardır.

namespace Association.Application.Services.DonationCategories;

public interface IDonationCategoryService
{
    Task<DonationCategory> GetAsync(
    Expression<Func<DonationCategory, bool>> predicate);

    Task<ICollection<DonationCategory>> GetListAsync(
        Expression<Func<DonationCategory, bool>>? predicate = null);

    Task<bool> AnyAsync(Expression<Func<DonationCategory, bool>> predicate);

    Task<DonationCategory> AddAsync(DonationCategory entity);
    Task<DonationCategory> UpdateAsync(DonationCategory entity);
    Task<DonationCategory> DeleteAsync(DonationCategory entity);
}