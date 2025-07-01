using System;

namespace CARTER.Models.ClubCoaches
{
    public class ClubCoachCreateRequest
    {
        public Guid? ClubId { get; set; }
        public Guid? CoachId { get; set; }
        //public DateTime? JoinDate { get; set; }
    }
}
