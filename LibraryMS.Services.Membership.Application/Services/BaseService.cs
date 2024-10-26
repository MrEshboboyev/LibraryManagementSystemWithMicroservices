using AutoMapper;
using LibraryMS.Services.Membership.Application.Common.Interfaces;

namespace LibraryMS.Services.Membership.Application.Services;

public abstract class BaseService(IUnitOfWork unitOfWork, IMapper mapper)
{
    protected readonly IUnitOfWork UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    protected readonly IMapper Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
}
