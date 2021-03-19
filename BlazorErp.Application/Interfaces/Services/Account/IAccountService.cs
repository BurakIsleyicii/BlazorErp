using BlazorErp.Application.Interfaces.Common;
using BlazorErp.Application.Requests.Identity;
using BlazorErp.Shared.Wrapper;
using System.Threading.Tasks;

namespace BlazorErp.Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, string userId);

        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, string userId);

        Task<IResult<string>> GetProfilePictureAsync(string userId);

        Task<IResult> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
    }
}