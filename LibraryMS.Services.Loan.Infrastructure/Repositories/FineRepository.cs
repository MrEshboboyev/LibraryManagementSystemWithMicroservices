using LibraryMS.Services.Loan.Application.Common.Interfaces;
using LibraryMS.Services.Loan.Domain.Entities;
using LibraryMS.Services.Loan.Infrastructure.Data;

namespace LibraryMS.Services.Loan.Infrastructure.Repositories;

public class FineRepository(LoanDbContext db) : Repository<Fine>(db),
    IFineRepository
{
}

