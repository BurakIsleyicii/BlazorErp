﻿using BlazorErp.Application.Requests.Identity;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorErp.Client.Pages.Identity
{
    public partial class RegisterUserModal
    {
        private bool success;
        private string[] errors = { };
        private MudForm form;

        [Parameter]
        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [Parameter]
        [Required]
        public string FirstName { get; set; }

        [Parameter]
        [Required]
        public string LastName { get; set; }

        [Parameter]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Parameter]
        [Required]
        public string Password { get; set; }

        [Parameter]
        [Required]
        public string ConfirmPassword { get; set; }

        [Parameter]
        public string PhoneNumber { get; set; }

        public bool ActivateUser { get; set; }
        public bool AutoConfirmEmail { get; set; }
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        public void Cancel()
        {
            MudDialog.Cancel();
        }
        private async Task SaveAsync()
        {
            form.Validate();
            if (form.IsValid)
            {
                var request = new RegisterRequest()
                {
                    Email = Email,
                    UserName = UserName,
                    FirstName = FirstName,
                    LastName = LastName,
                    Password = Password,
                    ConfirmPassword = ConfirmPassword,
                    PhoneNumber = PhoneNumber,
                    ActivateUser = ActivateUser,
                    AutoConfirmEmail = AutoConfirmEmail
                };
                var response = await _userManager.RegisterUserAsync(request);
                if (response.Succeeded)
                {
                    _snackBar.Add(localizer[response.Messages[0]], Severity.Success);
                    MudDialog.Close();
                }
                else
                {
                    foreach (var message in response.Messages)
                    {
                        _snackBar.Add(message, Severity.Error);
                    }
                }
            }
        }
        private IEnumerable<string> PasswordStrength(string pw)
        {
            if (string.IsNullOrWhiteSpace(pw))
            {
                yield return "Password is required!";
                yield break;
            }
            if (pw.Length < 8)
                yield return "Password must be at least of length 8";
            if (!Regex.IsMatch(pw, @"[A-Z]"))
                yield return "Password must contain at least one capital letter";
            if (!Regex.IsMatch(pw, @"[a-z]"))
                yield return "Password must contain at least one lowercase letter";
            if (!Regex.IsMatch(pw, @"[0-9]"))
                yield return "Password must contain at least one digit";
        }

        private MudTextField<string> pwField;

        private string PasswordMatch(string arg)
        {
            if (pwField.Value != arg)
                return "Passwords don't match";
            return null;
        }

        private bool PasswordVisibility;
        private InputType PasswordInput = InputType.Password;
        private string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        private void TogglePasswordVisibility()
        {
            if (PasswordVisibility)
            {
                PasswordVisibility = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                PasswordVisibility = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }
    }
}