using CARTER.Models.Common;

namespace CARTER.Models.Exercises
{
    public class ExercisePagingRequest : PagingRequestBase
    {
        public string OrderBy { get; set; }
        public string OrderDir { get; set; } = "ASC";
    }
}
