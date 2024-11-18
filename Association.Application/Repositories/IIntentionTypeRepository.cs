using Association.Application.Common;
using Association.Core.Entities;

namespace Association.Application.Repositories;

public interface IIntentionTypeRepository : IAsyncRepository<IntentionType, Guid> { }