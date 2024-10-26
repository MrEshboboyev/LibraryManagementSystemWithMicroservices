using AutoMapper;
using LibraryMS.Services.Catalog.Application.Common.Interfaces;

namespace LibraryMS.Services.Catalog.Application.Services;

public abstract class BaseService(IUnitOfWork unitOfWork, IMapper mapper)
{
    protected readonly IUnitOfWork _unitOfWork = unitOfWork;
    protected readonly IMapper _mapper = mapper;
}
