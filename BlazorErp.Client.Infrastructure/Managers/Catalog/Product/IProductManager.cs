using BlazorErp.Application.Features.Products.Commands.AddEdit;
using BlazorErp.Application.Features.Products.Queries.GetAllPaged;
using BlazorErp.Application.Requests.Catalog;
using BlazorErp.Shared.Wrapper;
using System.Threading.Tasks;

namespace BlazorErp.Client.Infrastructure.Managers.Catalog.Product
{
    public interface IProductManager : IManager
    {
        Task<PaginatedResult<GetAllPagedProductsResponse>> GetProductsAsync(GetAllPagedProductsRequest request);

        Task<IResult<string>> GetProductImageAsync(int id);

        Task<IResult<int>> SaveAsync(AddEditProductCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}