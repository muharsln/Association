using Association.Application.Common;
using Association.Core.Entities;

namespace Association.Application.Repositories;

public interface IDonationFormRepository : IAsyncRepository<DonationForm, Guid> { }
