using System;

namespace CARTER.Models.Players
{
    public class PlayerCreateRequest
    {
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public Guid? AppUserId { get; set; }
        public int? AgeId { get; set; }
        public int? NationalityId { get; set; }
    }
}
