using AutoMapper;
using BlazorErp.Application.Requests.Identity;
using BlazorErp.Application.Responses.Identity;

namespace BlazorErp.Client.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<PermissionResponse, PermissionRequest>().ReverseMap();
            CreateMap<RoleClaimsResponse, RoleClaimsRequest>().ReverseMap();
        }
    }
}