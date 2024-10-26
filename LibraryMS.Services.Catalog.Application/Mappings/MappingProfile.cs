using AutoMapper;
using LibraryMS.Services.Catalog.Application.DTOs;
using LibraryMS.Services.Catalog.Domain.Entities;

namespace LibraryMS.Services.Catalog.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region Author
        CreateMap<Author, AuthorDTO>()
            .ForMember(dest => dest.BookDTOs, opt => opt.MapFrom(src => src.Books))
            .ReverseMap()
                .ForMember(dest => dest.Books, opt => opt.Ignore());
        #endregion

        #region Book
        CreateMap<Book, BookDTO>()
            .ForMember(dest => dest.AuthorDTO, opt => opt.MapFrom(src => src.Author))
            .ForMember(dest => dest.CategoryDTO, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.PublisherDTO, opt => opt.MapFrom(src => src.Publisher))
            .ReverseMap()
                .ForMember(dest => dest.Author, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.Publisher, opt => opt.Ignore());
        #endregion

        #region Category
        CreateMap<Category, CategoryDTO>()
            .ForMember(dest => dest.BookDTOs, opt => opt.MapFrom(src => src.Books))
            .ReverseMap()
                .ForMember(dest => dest.Books, opt => opt.Ignore());
        #endregion

        #region Publisher
        CreateMap<Publisher, PublisherDTO>()
            .ForMember(dest => dest.BookDTOs, opt => opt.MapFrom(src => src.Books))
            .ReverseMap()
                .ForMember(dest => dest.Books, opt => opt.Ignore());
        #endregion
    }
}
