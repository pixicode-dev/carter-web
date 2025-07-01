using CARTER.Models.System.Users;

namespace CARTER.Models.Coaches
{
    public class CoachModel : CoachBaseModel
    {
        public AppUserModel AppUser { get; set; }
    }
}
