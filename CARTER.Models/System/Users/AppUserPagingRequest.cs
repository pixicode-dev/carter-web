using CARTER.Models.Common;

namespace CARTER.Models.System.Users
{
    public class AppUserPagingRequest : PagingRequestBase
    {
        public string Role { get; set; }
        public string OrderBy { get; set; }
        public string OrderDir { get; set; } = "ASC";
    }
}
