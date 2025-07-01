using System.Collections.Generic;

namespace CARTER.Models.Common
{
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public List<object> Errors { get; set; }
        //public int Code { get; set; }

        public ApiResult()
        {
            Message = string.Empty;
        }
    }
}
