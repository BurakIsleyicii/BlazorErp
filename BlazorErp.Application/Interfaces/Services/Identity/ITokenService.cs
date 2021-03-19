using BlazorErp.Application.Interfaces.Common;
using BlazorErp.Application.Requests.Identity;
using BlazorErp.Application.Responses.Identity;
using BlazorErp.Shared.Wrapper;
using System.Threading.Tasks;

namespace BlazorErp.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);
        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}