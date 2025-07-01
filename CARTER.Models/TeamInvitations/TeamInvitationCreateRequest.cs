using System;

namespace CARTER.Models.TeamInvitations
{
    public class TeamInvitationCreateRequest
    {
        public Guid? TeamId { get; set; }
        public Guid? PlayerId { get; set; }
        public string Message { get; set; }
    }
}
