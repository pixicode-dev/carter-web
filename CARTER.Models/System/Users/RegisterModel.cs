using System;
using System.Text.Json.Serialization;

namespace CARTER.Models.System.Users
{
    public class RegisterModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [JsonIgnore]
        public string Role { get; set; }
        [JsonIgnore]
        public string VerificationCode { get; set; }
    }
}
