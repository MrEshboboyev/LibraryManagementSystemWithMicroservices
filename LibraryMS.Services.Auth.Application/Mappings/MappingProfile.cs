using AutoMapper;
using LibraryMS.Services.Auth.Application.DTOs;
using LibraryMS.Services.Auth.Domain.Entities;

namespace LibraryMS.Services.Auth.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region AppUser
        // AppUser -> UserDTO
        CreateMap<AppUser, UserDTO>()
            .ReverseMap();
        #endregion
    }
}
