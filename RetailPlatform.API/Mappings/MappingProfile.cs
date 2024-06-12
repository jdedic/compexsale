using RetailPlatform.API.Models.DTO;
using RetailPlatform.API.Models.DTO.Add;
using RetailPlatform.API.Models.DTO.HomePage;
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
                dest.DateOfCreation,
                opt => opt.MapFrom(src => src.CreationDate.ToString("s")))
                .ForMember(dest =>
                dest.UniqueId,
                opt => opt.MapFrom(src => Int32.Parse(src.UniqueId).ToString("D6")))
                .ForMember(dest =>
                dest.Status,
                opt => opt.MapFrom(src => src.Active == false ? "Kreiran" : "Aktivan"));

            CreateMap<Add, RequestDTO>()
                .ForMember(dest =>
                dest.Category,
                opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest =>
                dest.DateOfCreation,
                opt => opt.MapFrom(src => src.CreationDate.ToString("s")));

            CreateMap<Add, AddModel>()
                .ForMember(dest =>
                dest.PublicationDate,
                opt => opt.MapFrom(src => src.CreationDate.ToString("dd.MM.yyyy")))
                .ForMember(dest =>
                dest.Location,
                opt => opt.MapFrom(src => src.Place))
                .ForMember(dest =>
                dest.ImagePath,
                opt => opt.MapFrom(src => "https://api.compexsale.org" + src.ImgUrl1))
                .ForMember(dest =>
                dest.Status,
                opt => opt.MapFrom(src => src.Active == false ? "Kreiran" : "Aktivan"));

            CreateMap<Add, EditAddDTO>()
                .ForMember(dest =>
                dest.SelectedCategory,
                opt => opt.MapFrom(src => src.SubCategoryId.ToString()))
                .ForMember(dest =>
                dest.SelectedUnit,
                opt => opt.MapFrom(src => src.UnitTypeId.ToString()))
                 .ForMember(dest =>
                dest.UniqueId,
                opt => opt.MapFrom(src => Int32.Parse(src.UniqueId).ToString("D6")))
                .ForMember(dest =>
                dest.SelectedCategory1,
                opt => opt.MapFrom(src => src.SubCategoryId1 != null ? src.SubCategoryId1.ToString() : ""))
               .ForMember(dest =>
                dest.SelectedCategory2,
                opt => opt.MapFrom(src => src.SubCategoryId2 != null ? src.SubCategoryId2.ToString() : ""))
               .ForMember(dest =>
                dest.SelectedCategory3,
                opt => opt.MapFrom(src => src.SubCategoryId3 != null ? src.SubCategoryId3.ToString() : ""));
                

            CreateMap<Add, EditRequestDTO>()
                .ForMember(dest =>
                dest.SelectedCategory,
                opt => opt.MapFrom(src => src.SubCategoryId.ToString()));

            CreateMap<CreateAddDTO, Add>()
               .ForMember(dest =>
               dest.SubCategoryId,
               opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SelectedCategory) ? 0 : Int32.Parse(src.SelectedCategory)))
               .ForMember(dest =>
               dest.UnitTypeId,
               opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SelectedUnit) ? 0 : Int32.Parse(src.SelectedUnit)))
               .ForMember(dest =>
               dest.SubCategoryId1,
               opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SelectedCategory1) ? 0 : Int32.Parse(src.SelectedCategory1)))
               .ForMember(dest =>
               dest.SubCategoryId2,
               opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SelectedCategory2) ? 0 : Int32.Parse(src.SelectedCategory2)))
               .ForMember(dest =>
               dest.SubCategoryId3,
               opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SelectedCategory3) ? 0 : Int32.Parse(src.SelectedCategory3)));

            CreateMap<CreateRequestDTO, Add>()
              .ForMember(dest =>
              dest.SubCategoryId,
              opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SelectedCategory) ? 0 : Int32.Parse(src.SelectedCategory)));


            CreateMap<EditAddDTO, Add>()
              .ForMember(dest =>
              dest.SubCategoryId,
              opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SelectedCategory) ? 0 : Int32.Parse(src.SelectedCategory)))
              .ForMember(dest =>
              dest.UnitTypeId,
              opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SelectedUnit) ? 0 : Int32.Parse(src.SelectedUnit)))
              .ForMember(dest =>
              dest.UniqueId,
              opt => opt.MapFrom(src => Int32.Parse(src.UniqueId)))
              .ForMember(dest =>
              dest.SubCategoryId1,
              opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SelectedCategory1) ? 0 : Int32.Parse(src.SelectedCategory1)))
              .ForMember(dest =>
              dest.SubCategoryId2,
              opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SelectedCategory2) ? 0 : Int32.Parse(src.SelectedCategory2)))
              .ForMember(dest =>
              dest.SubCategoryId3,
              opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SelectedCategory3) ? 0 : Int32.Parse(src.SelectedCategory3))); 
              

            CreateMap<EditRequestDTO, Add>()
             .ForMember(dest =>
             dest.SubCategoryId,
             opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.SelectedCategory) ? 0 : Int32.Parse(src.SelectedCategory)));


            CreateMap<SubCategory, SubCategoryModel>()
              .ForMember(dest =>
              dest.Category,
              opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<SubCategoryDTO, SubCategory>();
            CreateMap<SubCategory, SubCategoryDTO>();
            CreateMap<ProfileDTO, ProfileModel>();
            CreateMap<ProfileModel, ProfileModelDTO>();
            CreateMap<PrivateAccountDTO, ProfileModel>()
                .ForMember(dest => dest.LegalEntity, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.AgreeWithTermsAndConditions, opt => opt.MapFrom(src => true));

            CreateMap<ProfileModel, EditPrivateAccountDTO>()
                .ForMember(dest =>
                dest.Password,
                opt => opt.MapFrom(src => string.Empty));
            CreateMap<EditPrivateAccountDTO, ProfileModel>()
                .ForMember(dest => dest.LegalEntity, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.AgreeWithTermsAndConditions, opt => opt.MapFrom(src => true));

            CreateMap<ProfileModel, BusinessAccountModel>();
            CreateMap<CreateBusinessAccountDTO, ProfileModel>()
               .ForMember(dest => dest.LegalEntity, opt => opt.MapFrom(src => true))
               .ForMember(dest => dest.AgreeWithTermsAndConditions, opt => opt.MapFrom(src => true));
            CreateMap<ProfileModel, EditBusinessAccountDTO>()
              .ForMember(dest =>
              dest.Password,
              opt => opt.MapFrom(src => string.Empty));
            CreateMap<EditBusinessAccountDTO, ProfileModel>()
                .ForMember(dest => dest.LegalEntity, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.AgreeWithTermsAndConditions, opt => opt.MapFrom(src => true));
            CreateMap<Add, ProductPreviewDTO>()
                .ForMember(dest =>
                dest.IsComepnsation,
                 opt => opt.MapFrom(src => src.IsComepnsation ? "kompenzacija" : ""))
                .ForMember(dest =>
                dest.IsDiscontSale,
                opt => opt.MapFrom(src => src.IsDiscontSale ? "diskontna prodaja" : ""))
                .ForMember(dest =>
                dest.IsExchange,
                opt => opt.MapFrom(src => src.IsExchange ? "Razmena" : ""))
                .ForMember(dest =>
                dest.Active,
                opt => opt.MapFrom(src => src.Active ? "Aktivan" : "Neaktivan"))
                .ForMember(dest =>
                dest.ImgUrl1,
                opt => opt.MapFrom(src => src.ImgUrl1 != null ? src.ImgUrl1 : "/images/icon/default-image.png"))
                .ForMember(dest =>
                dest.ImgUrl2,
                opt => opt.MapFrom(src => src.ImgUrl2 != null ? src.ImgUrl2 : "/images/icon/default-image.png"))
                .ForMember(dest =>
                dest.ImgUrl3,
                opt => opt.MapFrom(src => src.ImgUrl3 != null ? src.ImgUrl3 : "/images/icon/default-image.png"))
                .ForMember(dest =>
                dest.ImgUrl4,
                opt => opt.MapFrom(src => src.ImgUrl4 != null ? src.ImgUrl4 : "/images/icon/default-image.png"))
                .ForMember(dest =>
                dest.Price,
                opt => opt.MapFrom(src => String.Format("{0:n0}", src.Price)));
        }
    }
}
