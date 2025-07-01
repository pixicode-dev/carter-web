namespace CARTER.Models.Common
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult(T data)
        {
            Success = true;
            Data = data;
            //Code = StatusCodes.Status200OK;
            Message = string.Empty;
        }

        public ApiSuccessResult(T data, string message)
        {
            Success = true;
            Data = data;
            //Code = StatusCodes.Status200OK;
            Message = message;
        }

        public ApiSuccessResult()
        {
            Success = true;
            //Code = StatusCodes.Status200OK;
            Message = string.Empty;
        }
    }
}
