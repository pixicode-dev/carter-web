using CARTER.Models.Common;

namespace CARTER.Models.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
