using CARTER.Models.Common;
using System;

namespace CARTER.Models.TeamInvitations
{
    public class TeamInvitationModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid? TeamId { get; set; }
        public Guid? PlayerId { get; set; }
        public string Message { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsApproved { get; set; }
        public TeamInvitationModel()
        {
            IsConfirmed = false;
            IsApproved = false;
        }
    }
}
