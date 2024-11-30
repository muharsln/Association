using Association.Application.Repositories;
using Association.Core.Entities;
using Association.Persistence.Context;
using Association.Persistence.Repositories.Common;

namespace Association.Persistence.Repositories;
public class DonationGroupRepository(AssociationDbContext context) : EfRepositoryBase<DonationGroup, Guid, AssociationDbContext>(context), IDonationGroupRepository { }
