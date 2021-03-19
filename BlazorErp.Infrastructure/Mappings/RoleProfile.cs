using AutoMapper;
using BlazorErp.Application.Responses.Identity;
using Microsoft.AspNetCore.Identity;

namespace BlazorErp.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, IdentityRole>().ReverseMap();
        }
    }
}