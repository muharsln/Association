﻿using Association.Application.Repositories;
using Association.Core.Entities;
using Association.Persistence.Context;
using Association.Persistence.Repositories.Common;

namespace Association.Persistence.Repositories;

public class DonationGroupRepository : EfRepositoryBase<DonationGroup, Guid, AppDbContext>, IDonationGroupRepository
{
    public DonationGroupRepository(AppDbContext context) : base(context) { }
}