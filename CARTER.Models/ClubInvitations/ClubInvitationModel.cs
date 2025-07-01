using CARTER.Models.Common;
using System;

namespace CARTER.Models.ClubInvitations
{
    public class ClubInvitationModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid? ClubId { get; set; }
        public Guid? CoachId { get; set; }
        public string Message { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsApproved { get; set; }
        public ClubInvitationModel()
        {
            IsConfirmed = false;
            IsApproved = false;
        }
    }
}
