using Association.Application.Repositories;
using Association.Core.Entities;
using Association.Persistence.Context;
using Association.Persistence.Repositories.Common;

namespace Association.Persistence.Repositories;
public class DonorRepository(AssociationDbContext context) : EfRepositoryBase<Donor, Guid, AssociationDbContext>(context), IDonorRepository { }
