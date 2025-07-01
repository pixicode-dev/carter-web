using System;

namespace CARTER.Models.System.Users
{
    public class ChangeStatusRequest
    {
        public Guid AppUserId { get; set; }
        public bool IsActive { get; set; }
    }
}
