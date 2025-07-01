using System;

namespace CARTER.Models.ClubCoaches
{
    public class ClubCoachUpdateRequest
    {
        //public Guid Id { get; set; }
        public Guid? ClubId { get; set; }
        public Guid? CoachId { get; set; }
        //public DateTime? JoinDate { get; set; }
    }
}
