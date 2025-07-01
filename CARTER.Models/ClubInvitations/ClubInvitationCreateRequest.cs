using System;

namespace CARTER.Models.ClubInvitations
{
    public class ClubInvitationCreateRequest
    {
        public Guid? ClubId { get; set; }
        public Guid? CoachId { get; set; }
        public string Message { get; set; }

    }
}
