using AutoMapper;
using LibraryMS.Services.Loan.Application.Common.Interfaces;

namespace LibraryMS.Services.Loan.Application.Services;

public abstract class BaseService(IUnitOfWork unitOfWork, IMapper mapper)
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IMapper _mapper = mapper;
}
