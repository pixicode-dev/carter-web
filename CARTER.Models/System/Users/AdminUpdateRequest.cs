using Microsoft.AspNetCore.Http;

namespace CARTER.Models.System.Users
{
    public class AdminUpdateRequest : AppUserUpdateRequest
    {
        public IFormFile AvatarFile { get; set; }

    }
}
