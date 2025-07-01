using CARTER.Models.System.Users;
using System.Collections.Generic;

namespace CARTER.Models.Players
{
    public class PlayerUpdateRequest : AppUserUpdateRequest
    {
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public List<int> PositionIds { get; set; }
        public string MotherPhoneNumber { get; set; }
        public string FatherPhoneNumber { get; set; }
    }
}
