using System;

namespace CARTER.Models.Coaches
{
    public class CoachCreateRequest
    {

        public int? CoachLevelId { get; set; }
        public Guid? AppUserId { get; set; }
    }
}
