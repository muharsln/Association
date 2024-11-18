using Association.Application.Repositories;
using Association.Core.Entities;
using Association.Persistence.Context;
using Association.Persistence.Repositories.Common;

namespace Association.Persistence.Repositories;

public class DonationCategoryRepository : EfRepositoryBase<DonationCategory, Guid, AppDbContext>, IDonationCategoryRepository
{
    public DonationCategoryRepository(AppDbContext context) : base(context) { }
}
