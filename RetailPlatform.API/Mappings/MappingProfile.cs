using RetailPlatform.API.Models.DTO;
using RetailPlatform.Common.Entities;
using System;

namespace RetailPlatform.API.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => 
                dest.Password,
                opt => opt.MapFrom(src => string.Empty));
            CreateMap<UserDTO, User>()
                .ForMember(dest =>
                dest.RegistrationDate,
                opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<User, EditUserDTO>()
                .ForMember(dest =>
                dest.Password,
                opt => opt.MapFrom(src => string.Empty));
            CreateMap<EditUserDTO, User>();

            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();

            CreateMap<Add, AddDTO>()
                .ForMember(dest =>
                dest.CreatedBy,
                opt => opt.MapFrom(src => src.Profile != null ? src.Profile.CompanyName : null))
                .ForMember(dest =>
                dest.Category,
                opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null))
                .ForMember(dest =>
                dest.DateOfCreation,
                opt => opt.MapFrom(src => src.CreationDate.ToString("s")));
        }
    }
}
