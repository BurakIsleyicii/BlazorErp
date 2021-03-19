using BlazorErp.Application.Requests.Identity;
using BlazorErp.Shared.Wrapper;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorErp.Client.Infrastructure.Managers.Identity.Authentication
{
    public interface IAuthenticationManager : IManager
    {
        Task<IResult> Login(TokenRequest model);

        Task<IResult> Logout();
        Task<string> RefreshToken();
        Task<string> TryRefreshToken();

        Task<ClaimsPrincipal> CurrentUser();
    }
}