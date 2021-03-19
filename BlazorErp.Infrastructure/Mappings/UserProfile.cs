using AutoMapper;
using BlazorErp.Application.Responses.Identity;
using BlazorErp.Shared.Models.Identity;

namespace BlazorErp.Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserResponse, BlazorHeroUser>().ReverseMap();
        }
    }
}