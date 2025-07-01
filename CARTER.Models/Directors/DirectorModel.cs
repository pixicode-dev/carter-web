using CARTER.Models.System.Users;

namespace CARTER.Models.Directors
{
    public class DirectorModel : DirectorBaseModel
    {
        public AppUserModel AppUser { get; set; }
    }
}
