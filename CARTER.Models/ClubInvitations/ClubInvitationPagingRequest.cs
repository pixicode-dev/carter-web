using CARTER.Models.Common;
using System;

namespace CARTER.Models.ClubInvitations
{
    public class ClubInvitationPagingRequest : PagingRequestBase
    {
        public Guid? ClubId { get; set; }
        public Guid? CoachId { get; set; }
        public Guid? InvitedBy { get; set; }
        public string Message { get; set; }
        public bool? IsConfirmed { get; set; }
        public bool? IsApproved { get; set; }
    }
}
