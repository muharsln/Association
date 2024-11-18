using Association.Application.Repositories;
using Association.Core.Entities;
using Association.Persistence.Context;
using Association.Persistence.Repositories.Common;

namespace Association.Persistence.Repositories;

public class IntentionTypeRepository : EfRepositoryBase<IntentionType, Guid, AppDbContext>, IIntentionTypeRepository
{
    public IntentionTypeRepository(AppDbContext context) : base(context) { }
}