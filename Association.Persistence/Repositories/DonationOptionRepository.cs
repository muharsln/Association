using Association.Application.Repositories;
using Association.Core.Entities;
using Association.Persistence.Context;
using Association.Persistence.Repositories.Common;

namespace Association.Persistence.Repositories;

public class DonationOptionRepository : EfRepositoryBase<DonationOption, Guid, AppDbContext>, IDonationOptionRepository
{
    public DonationOptionRepository(AppDbContext context) : base(context) { }
}
