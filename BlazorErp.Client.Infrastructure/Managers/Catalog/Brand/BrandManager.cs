using BlazorErp.Application.Features.Brands.AddEdit;
using BlazorErp.Application.Features.Brands.Queries.GetAll;
using BlazorErp.Client.Infrastructure.Extensions;
using BlazorErp.Shared.Wrapper;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorErp.Client.Infrastructure.Managers.Catalog.Brand
{
    public class BrandManager : IBrandManager
    {
        private readonly HttpClient _httpClient;

        public BrandManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.BrandsEndpoint.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<IResult<List<GetAllBrandsResponse>>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync(Routes.BrandsEndpoint.GetAll);
            return await response.ToResult<List<GetAllBrandsResponse>>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditBrandCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.BrandsEndpoint.Save, request);
            return await response.ToResult<int>();
        }
    }
}