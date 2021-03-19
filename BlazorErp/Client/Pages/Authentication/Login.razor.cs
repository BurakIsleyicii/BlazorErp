using BlazorErp.Application.Requests.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorErp.Client.Pages.Authentication
{
    public partial class Login
    {
        private TokenRequest model = new TokenRequest();

        protected override async Task OnInitializedAsync()
        {
            var state = await _stateProvider.GetAuthenticationStateAsync();
            if (state != new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())))
            {
                _navigationManager.NavigateTo("/");
            }
        }

        private async Task SubmitAsync()
        {
            var result = await _authenticationManager.Login(model);
            if (result.Succeeded)
            {
                _snackBar.Add($"Welcome {model.Email}.", Severity.Success);
                _navigationManager.NavigateTo("/", true);
            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        private void FillAdminstratorCredentials()
        {
            model.Email = "admin@erp.com";
            model.Password = "123Pa$$word!";
        }

        private void FillBasicUserCredentials()
        {
            model.Email = "burak@erp.com";
            model.Password = "123Pa$$word!";
        }
    }
}