using LibraryMS.Services.Loan.Application.Common.Interfaces;
using LibraryMS.Services.Loan.Infrastructure.Data;

namespace LibraryMS.Services.Loan.Infrastructure.Repositories;

public class UnitOfWork(LoanDbContext db) : IUnitOfWork
{
    private readonly LoanDbContext _db = db;

    public IBookLoanRepository BookLoan { get; private set; } = new BookLoanRepository(db);
    public IFineRepository Fine { get; private set; } = new FineRepository(db);

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}
