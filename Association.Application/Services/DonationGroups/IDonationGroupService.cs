using Association.Core.Entities;
using System.Linq.Expressions;

// Bu servisler, uygulama katmanında kullanılacak olan repository'lerle çalışır.
// Repository'ler, veritabanı işlemlerini gerçekleştiren sınıflardır.

namespace Association.Application.Services.DonationGroups;

public interface IDonationGroupService
{
    Task<DonationGroup> GetAsync(
    Expression<Func<DonationGroup, bool>> predicate);

    Task<bool> AnyAsync(Expression<Func<DonationGroup, bool>> predicate);

    Task<ICollection<DonationGroup>> GetListAsync(
        Expression<Func<DonationGroup, bool>>? predicate = null);

    Task<DonationGroup> AddAsync(DonationGroup entity);
    Task<DonationGroup> UpdateAsync(DonationGroup entity);
    Task<DonationGroup> DeleteAsync(DonationGroup entity);
}
