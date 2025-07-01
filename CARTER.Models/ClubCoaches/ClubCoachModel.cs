using CARTER.Models.Common;
using System;

namespace CARTER.Models.ClubCoaches
{
    public class ClubCoachModel : BaseModel

    {
        public Guid Id { get; set; }
        public Guid? ClubId { get; set; }
        public Guid? CoachId { get; set; }
        //public DateTime? JoinDate { get; set; }
    }
}
