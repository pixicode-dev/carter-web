using CARTER.Models.Common;
using System;

namespace CARTER.Models.Clubs
{
    public class ClubPagingRequest : PagingRequestBase
    {
        public Guid? DirectorId { get; set; }
    }
}
