using CARTER.Models.Common;
using System;

namespace CARTER.Models.Directors
{
    public class DirectorPagingRequest : PagingRequestBase
    {
        public Guid? UserId { get; set; }
        public Guid? ClubId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
