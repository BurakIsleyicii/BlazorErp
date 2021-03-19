using BlazorErp.Application.Interfaces.Common;

namespace BlazorErp.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}