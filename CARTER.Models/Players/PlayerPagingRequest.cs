using CARTER.Models.Common;
using System;

namespace CARTER.Models.Players
{
    public class PlayerPagingRequest : PagingRequestBase
    {
        //public Guid? UserId { get; set; }
        public Guid? ClubId { get; set; }
        public Guid? TeamId { get; set; }
        public Guid? CoachId { get; set; }
        public Guid? IndividualCoachId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }

    }
}
