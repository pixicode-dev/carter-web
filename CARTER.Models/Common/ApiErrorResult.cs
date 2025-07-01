namespace CARTER.Models.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public ApiErrorResult()
        {
            Message = string.Empty;
        }

        public ApiErrorResult(string message)
        {
            Success = false;
            //Code = StatusCodes.Status400BadRequest;
            Message = message;
        }

        public ApiErrorResult(string message, T data)
        {
            Success = false;
            //Code = StatusCodes.Status400BadRequest;
            Message = message;
            Data = data;
        }

        //public ApiErrorResult(List<object> errors)
        //{
        //    Success = false;
        //    Message = "BAD_REQUEST";
        //    //Code = StatusCodes.Status400BadRequest;
        //    Errors = errors;
        //}
        //public ApiErrorResult(ModelStateDictionary modelState)
        //{
        //    Success = false;
        //    Message = SystemMessageCodes.BAD_REQUEST.ToString();
        //    //Code = StatusCodes.Status400BadRequest;
        //    var modelErrors = modelState.Keys.Where(k => !string.IsNullOrEmpty(k))
        //            .SelectMany(key => modelState[key].Errors.Select(x => (object)new ModelStateError(key, x.ErrorMessage)))
        //            .ToList();
        //    Errors = modelErrors.Count > 0 ? modelErrors : null;
        //}
    }
}
