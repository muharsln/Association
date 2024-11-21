using Association.Application.Repositories;
using Association.Core.Entities;
using System.Linq.Expressions;

// Bu servisler, uygulama katmanında kullanılacak olan repository'lerle çalışır.
// Repository'ler, veritabanı işlemlerini gerçekleştiren sınıflardır.

namespace Association.Application.Services.IntentionTypes;

public class IntentionTypeManager : IIntentionTypeService
{
    private readonly IIntentionTypeRepository _intentionTypeRepository;

    public IntentionTypeManager(IIntentionTypeRepository intentionTypeRepository)
    {
        _intentionTypeRepository = intentionTypeRepository;
    }

    public async Task<IntentionType> AddAsync(IntentionType entity)
    {
        IntentionType addedIntentionType = await _intentionTypeRepository.AddAsync(entity);
        return addedIntentionType;
    }

    public Task<bool> AnyAsync(Expression<Func<IntentionType, bool>> predicate)
    {
        var anyIntentionType = _intentionTypeRepository.AnyAsync(predicate);
        return anyIntentionType;
    }

    public async Task<IntentionType> DeleteAsync(IntentionType entity)
    {
        IntentionType deletedIntentionType = await _intentionTypeRepository.DeleteAsync(entity);
        return deletedIntentionType;
    }

    public async Task<IntentionType> GetAsync(Expression<Func<IntentionType, bool>> predicate)
    {
        IntentionType? intentionType = await _intentionTypeRepository.GetAsync(predicate);
        return intentionType;
    }

    public async Task<ICollection<IntentionType>> GetListAsync(Expression<Func<IntentionType, bool>>? predicate = null)
    {
        ICollection<IntentionType> intentionTypes = await _intentionTypeRepository.GetListAsync(predicate);
        return intentionTypes;
    }

    public async Task<IntentionType> UpdateAsync(IntentionType entity)
    {
        IntentionType updatedIntentionType = await _intentionTypeRepository.UpdateAsync(entity);
        return updatedIntentionType;
    }
}