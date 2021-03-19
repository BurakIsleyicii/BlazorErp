using BlazorErp.Application.Features.Dashboard.GetData;
using BlazorErp.Shared.Wrapper;
using System.Threading.Tasks;

namespace BlazorErp.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}