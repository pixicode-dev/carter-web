using CARTER.Models.System.Users;

namespace CARTER.Models.Players
{
    public class PlayerModel : PlayerBaseModel
    {
        public AppUserModel AppUser { get; set; }
    }
}
