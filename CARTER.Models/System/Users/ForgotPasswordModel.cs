using System.Text.Json.Serialization;

namespace CARTER.Models.System.Users
{
    public class ForgotPasswordModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string VerificationCode { get; set; }
    }
}
