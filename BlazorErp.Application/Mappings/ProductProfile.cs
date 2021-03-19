using AutoMapper;
using BlazorErp.Application.Features.Products.Commands.AddEdit;
using BlazorErp.Domain.Entities.Catalog;

namespace BlazorErp.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddEditProductCommand, Product>().ReverseMap();
        }
    }
}