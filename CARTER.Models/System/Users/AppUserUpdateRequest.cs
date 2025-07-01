using CARTER.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace CARTER.Models.System.Users
{
    public class AppUserUpdateRequest
    {
        public string Avatar { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int? GenderId { get; set; }
        public LocationModel Location { get; set; }
        public int? YearOfBirth { get; set; }
        public string NationalityId { get; set; }

    }
}
