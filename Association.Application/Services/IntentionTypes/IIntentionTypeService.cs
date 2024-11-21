using Association.Core.Entities;
using System.Linq.Expressions;

// Bu servisler, uygulama katmanında kullanılacak olan repository'lerle çalışır.
// Repository'ler, veritabanı işlemlerini gerçekleştiren sınıflardır.

namespace Association.Application.Services.IntentionTypes;

public interface IIntentionTypeService
{
    Task<IntentionType> GetAsync(
    Expression<Func<IntentionType, bool>> predicate);

    Task<ICollection<IntentionType>> GetListAsync(
        Expression<Func<IntentionType, bool>>? predicate = null);

    Task<bool> AnyAsync(Expression<Func<IntentionType, bool>> predicate);

    Task<IntentionType> AddAsync(IntentionType entity);
    Task<IntentionType> UpdateAsync(IntentionType entity);
    Task<IntentionType> DeleteAsync(IntentionType entity);
}
