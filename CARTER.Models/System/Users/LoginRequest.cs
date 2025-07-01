using System.ComponentModel.DataAnnotations;

namespace CARTER.Models.System.Users
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string Timezone { get; set; }

    }
}
