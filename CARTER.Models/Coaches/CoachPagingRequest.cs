using CARTER.Models.Common;
using System;

namespace CARTER.Models.Coaches
{
    public class CoachPagingRequest : PagingRequestBase
    {
        public Guid? UserId { get; set; }
        public Guid? ClubId { get; set; }
        public Guid? TeamId { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? CoachLevel { get; set; }

    }
}
