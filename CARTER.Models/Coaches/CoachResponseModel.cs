using System;

namespace CARTER.Models.Coaches
{
    public class CoachResponseModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        //public string UserName { get; set; }

        public string PhoneNumber { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Gender { get; set; }
        public int? CoachLevel { get; set; }
        public Guid? AppUserId { get; set; }
    }
}
