using Association.Core.Entities.Common;
using System.Linq.Expressions;

namespace Association.Application.Common;
public interface IAsyncRepository<TEntity, IEntityId> where TEntity : BaseEntity<IEntityId>
{
    Task<TEntity> GetAsync(
    Expression<Func<TEntity, bool>> predicate,
    CancellationToken cancellationToken = default);

    Task<ICollection<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        CancellationToken cancellationToken = default);

    Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        CancellationToken cancellationToken = default);

    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default);

    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default);

    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

    Task<ICollection<TEntity>> DeleteRangeAsync(
         ICollection<TEntity> entities, CancellationToken cancellationToken = default);
}
