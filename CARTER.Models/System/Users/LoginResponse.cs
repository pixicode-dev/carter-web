using System;
using System.Text.Json.Serialization;

namespace CARTER.Models.System.Users
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        [JsonIgnore]
        public DateTime? ExpireDate { get; set; }
        public AppUserModel AppUser { get; set; }

    }
}
