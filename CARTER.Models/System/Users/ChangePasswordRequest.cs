using System.ComponentModel.DataAnnotations;

namespace CARTER.Models.System.Users
{
    public class ChangePasswordRequest
    {
        [Required(ErrorMessage = "Current password is required.")]
        [Display(Name = "Current password")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Confirm password and Password do not match.")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}
