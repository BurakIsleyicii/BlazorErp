using BlazorErp.Application.Features.Products.Commands.AddEdit;
using BlazorErp.Application.Features.Products.Queries.GetAllPaged;
using BlazorErp.Application.Requests.Catalog;
using BlazorErp.Client.Infrastructure.Extensions;
using BlazorErp.Shared.Wrapper;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorErp.Client.Infrastructure.Managers.Catalog.Product
{
    public class ProductManager : IProductManager
    {
        private readonly HttpClient _httpClient;

        public ProductManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.ProductsEndpoint.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<string>> GetProductImageAsync(int id)
        {
            var response = await _httpClient.GetAsync(Routes.ProductsEndpoint.GetProductImage(id));
            return await response.ToResult<string>();
        }

        public async Task<PaginatedResult<GetAllPagedProductsResponse>> GetProductsAsync(GetAllPagedProductsRequest request)
        {
            var response = await _httpClient.GetAsync(Routes.ProductsEndpoint.GetAllPaged(request.PageNumber, request.PageSize));
            return await response.ToPaginatedResult<GetAllPagedProductsResponse>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditProductCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.ProductsEndpoint.Save, request);
            return await response.ToResult<int>();
        }
    }
}