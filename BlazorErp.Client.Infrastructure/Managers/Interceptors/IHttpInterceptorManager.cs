using System.Threading.Tasks;
using Toolbelt.Blazor;

namespace BlazorErp.Client.Infrastructure.Managers.Interceptors
{
    public interface IHttpInterceptorManager : IManager
    {
        void RegisterEvent();
        Task InterceptBeforeHttpAsync(object sender, HttpClientInterceptorEventArgs e);
        void DisposeEvent();
    }
}
