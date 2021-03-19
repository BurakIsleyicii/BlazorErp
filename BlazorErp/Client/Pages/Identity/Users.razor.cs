﻿using BlazorErp.Application.Responses.Identity;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorErp.Client.Pages.Identity
{
    public partial class Users
    {
        public List<UserResponse> UserList = new List<UserResponse>();
        private UserResponse user = new UserResponse();
        private string searchString = "";

        protected override async Task OnInitializedAsync()
        {
            await GetUsersAsync();
        }
        private async Task GetUsersAsync()
        {
            var response = await _userManager.GetAllAsync();
            if (response.Succeeded)
            {
                UserList = response.Data.ToList();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        private bool Search(UserResponse user)
        {
            if (string.IsNullOrWhiteSpace(searchString)) return true;
            if (user.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        private async Task InvokeModal()
        {
            var parameters = new DialogParameters();
            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<RegisterUserModal>("Modal", parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await GetUsersAsync();
            }
        }

        private void ViewProfile(string userId)
        {
            _navigationManager.NavigateTo($"/user-profile/{userId}");
        }

        private void ManageRoles(string userId, string email)
        {
            if (email == "mukesh@blazorhero.com") _snackBar.Add("Not Allowed.", Severity.Error);
            else _navigationManager.NavigateTo($"/identity/user-roles/{userId}");
        }
    }
}