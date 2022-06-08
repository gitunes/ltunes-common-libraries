namespace LTunes.Lib.Shared.Models.Concrete
{
    public class ValidationResponse<T> : Response<T>
    {
        public ValidationResponse() : base(default, false)
        {
        }

        public ValidationResponse(string statusMessage) : base(default, false, statusMessage)
        {
        }

        public ValidationResponse(T data) : base(data, false)
        {
        }

        public ValidationResponse(T data, string statusMessage) : base(data, false, statusMessage)
        {
        }

        public ValidationResponse(T data, string statusMessage, StatusCodeType statusCode) : base(data, false, statusMessage, statusCode)
        {
        }
    }
}
