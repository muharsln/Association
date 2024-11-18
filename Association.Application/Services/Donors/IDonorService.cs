using Association.Core.Entities;
using System.Linq.Expressions;

// Bu servisler, uygulama katmanında kullanılacak olan repository'lerle çalışır.
// Repository'ler, veritabanı işlemlerini gerçekleştiren sınıflardır.

namespace Association.Application.Services.Donors;
public interface IDonorService
{
    Task<bool> AnyAsync(Expression<Func<Donor, bool>> predicate);

    Task<Donor> GetAsync(
    Expression<Func<Donor, bool>> predicate);

    Task<ICollection<Donor>> GetListAsync(
        Expression<Func<Donor, bool>>? predicate = null);

    Task<Donor> AddAsync(Donor entity);
    Task<Donor> UpdateAsync(Donor entity);
    Task<Donor> DeleteAsync(Donor entity);
}