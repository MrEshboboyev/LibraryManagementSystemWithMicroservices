using LibraryMS.Services.Membership.Application.Common.Interfaces;
using LibraryMS.Services.Membership.Domain.Entities;
using LibraryMS.Services.Membership.Infrastructure.Data;

namespace LibraryMS.Services.Membership.Infrastructure.Repositories;

public class MembershipTypeRepository(MembershipDbContext db) : Repository<MembershipType>(db),
    IMembershipTypeRepository
{
}

