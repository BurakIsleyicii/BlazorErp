using AutoMapper;
using BlazorErp.Application.Features.Brands.AddEdit;
using BlazorErp.Application.Features.Brands.Queries.GetAll;
using BlazorErp.Application.Features.Brands.Queries.GetById;
using BlazorErp.Domain.Entities.Catalog;

namespace BlazorErp.Application.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsResponse, Brand>().ReverseMap();
        }
    }
}