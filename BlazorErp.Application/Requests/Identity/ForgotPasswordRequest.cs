using System.ComponentModel.DataAnnotations;

namespace BlazorErp.Application.Requests.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}