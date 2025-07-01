using CARTER.Models.Coaches;
using CARTER.Models.Directors;
using CARTER.Models.Players;

namespace CARTER.Models.System.Users
{
    public class AppUserModel : AppUserBaseModel
    {
        public DirectorBaseModel Director { get; set; }
        public CoachBaseModel Coach { get; set; }
        public PlayerBaseModel Player { get; set; }
    }
}
