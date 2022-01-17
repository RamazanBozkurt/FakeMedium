using AutoMapper;
using FakeMedium.MODELS.DTO.Request.Category;
using FakeMedium.MODELS.DTO.Request.Content;
using FakeMedium.MODELS.DTO.Request.User;
using FakeMedium.MODELS.DTO.Response;
using FakeMedium.MODELS.DTO.Response.Category;
using FakeMedium.MODELS.DTO.Response.Content;
using FakeMedium.MODELS.DTO.Response.User;
using FakeMedium.MODELS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeMedium.SERVICES.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Content, HomeContentResponse>();
            CreateMap<AddNewContentRequest, Content>();
            CreateMap<UpdateContentRequest, Content>();
            CreateMap<Content, ContentSimpleResponse>();

            CreateMap<Category, CategorySimpleResponse>();
            CreateMap<AddNewCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();

            CreateMap<User, UserSimpleResponse>().ReverseMap();
            CreateMap<AddNewUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
        }
    }
}
