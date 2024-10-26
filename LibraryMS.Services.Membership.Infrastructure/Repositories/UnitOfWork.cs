using LibraryMS.Services.Membership.Application.Common.Interfaces;
using LibraryMS.Services.Membership.Infrastructure.Data;

namespace LibraryMS.Services.Membership.Infrastructure.Repositories
{
    public class UnitOfWork(MembershipDbContext db) : IUnitOfWork
    {
        private readonly MembershipDbContext _db = db;

        public IMemberRepository Member { get; private set; } = new MemberRepository(db);
        public IMembershipTypeRepository MembershipType { get; private set; } = new MembershipTypeRepository(db);
        public ILoanHistoryRepository LoanHistory { get; private set; } = new LoanHistoryRepository(db);

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
