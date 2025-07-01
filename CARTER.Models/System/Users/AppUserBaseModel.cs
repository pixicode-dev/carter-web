using CARTER.Models.Common;
using CARTER.Models.Nationalities;
using System;

namespace CARTER.Models.System.Users
{
    public class AppUserBaseModel : BaseModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public LocationModel Location { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public GenderModel Gender { get; set; }
        public int? YearOfBirth { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
        public NationalityModel Nationality { get; set; }
        //public ICollection<InvitationBaseModel> Invitations { get; set; }
        //public ICollection<ClubBaseModel> Clubs { get; set; }
        //public ICollection<TeamBaseModel> Teams { get; set; }
        public bool? IsInvitedToClub { get; set; }
        public bool? IsInvitedToTeam { get; set; }
        public bool? IsInvitedToEvent { get; set; }
        public int ExperiencePoint { get; set; }
        public int ExperiencePointAvailable { get; set; }
        public double EventPresenceRate { get; set; }

        public AppUserBaseModel()
        {
            CreatedDate = DateTime.UtcNow;
            ModifyDate = null;
            ModifyDate = null;
            IsActive = true;
        }
    }
}
