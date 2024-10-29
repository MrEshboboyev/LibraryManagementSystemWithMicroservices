using AutoMapper;
using LibraryMS.Services.Membership.Application.DTOs;
using LibraryMS.Services.Membership.Domain.Entities;

namespace LibraryMS.Services.Membership.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region Member
        CreateMap<Member, MemberDTO>()
            .ForMember(dest => dest.MembershipTypeDTO, opt => opt.MapFrom(src => src.MembershipType))
            .ReverseMap()
                .ForMember(dest => dest.MembershipType, opt => opt.Ignore());
        #endregion

        #region MembershipType
        CreateMap<MembershipType, MembershipTypeDTO>()
            .ForMember(dest => dest.MemberDTOs, opt => opt.MapFrom(src => src.Members))
            .ReverseMap()
                .ForMember(dest => dest.Members, opt => opt.Ignore());
        #endregion
    }
}
