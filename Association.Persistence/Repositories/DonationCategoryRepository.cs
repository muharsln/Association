using Association.Application.Repositories;
using Association.Core.Entities;
using Association.Persistence.Context;
using Association.Persistence.Repositories.Common;

namespace Association.Persistence.Repositories;
public class DonationCategoryRepository(AssociationDbContext context) : EfRepositoryBase<DonationCategory, Guid, AssociationDbContext>(context), IDonationCategoryRepository { }
