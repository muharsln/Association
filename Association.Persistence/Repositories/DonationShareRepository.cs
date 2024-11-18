using Association.Application.Repositories;
using Association.Core.Entities;
using Association.Persistence.Context;
using Association.Persistence.Repositories.Common;

namespace Association.Persistence.Repositories;

public class DonationShareRepository : EfRepositoryBase<DonationShare, Guid, AppDbContext>, IDonationShareRepository
{
    public DonationShareRepository(AppDbContext context) : base(context) { }
}
