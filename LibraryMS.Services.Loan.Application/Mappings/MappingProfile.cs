using AutoMapper;
using LibraryMS.Services.Loan.Application.DTOs;
using LibraryMS.Services.Loan.Domain.Entities;

namespace LibraryMS.Services.Loan.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region BookLoan
        CreateMap<BookLoan, BookLoanDTO>()
            .ForMember(dest => dest.FineDTO, opt => opt.MapFrom(src => src.Fine))
            .ReverseMap()
                .ForMember(dest => dest.Fine, opt => opt.Ignore());
        #endregion

        #region Fine
        CreateMap<Fine, FineDTO>()
            .ForMember(dest => dest.BookLoanDTO, opt => opt.MapFrom(src => src.BookLoan))
            .ReverseMap()
                .ForMember(dest => dest.BookLoan, opt => opt.Ignore());
        #endregion
    }
}
