using CARTER.Models.Common;
using System;

namespace CARTER.Models.Teams
{
    public class TeamPagingRequest : PagingRequestBase
    {
        public Guid? ClubId { get; set; }

        public Guid? CoachId { get; set; }

        public string Name { get; set; }

        public TeamPagingRequest()
        {
            Name = "";
            CoachId = null;
        }
    }
}
