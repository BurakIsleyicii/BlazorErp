using System.Collections.Generic;

namespace BlazorErp.Application.Responses.Identity
{
    public class GetAllUsersReponse
    {
        public IEnumerable<UserResponse> Users { get; set; }
    }
}