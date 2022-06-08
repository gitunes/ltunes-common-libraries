namespace LTunes.Lib.Shared.Models.Concrete
{
    public class SuccessResponse<T> : Response<T>
    {
        public SuccessResponse() : base(default, true, Message.Success, StatusCodeType.Success)
        {
        }

        public SuccessResponse(StatusCodeType statusCode) : base(default, true, Message.Success, statusCode)
        {
        }


        public SuccessResponse(string message) : base(default, true, message, StatusCodeType.Success)
        {
        }

        public SuccessResponse(T data) : base(data, true, Message.Success, StatusCodeType.Success)
        {
        }

        public SuccessResponse(T data, StatusCodeType statusCode) : base(data, true, Message.Success, statusCode)
        {
        }

        public SuccessResponse(T data, string statusMessage) : base(data, true, statusMessage, StatusCodeType.Success)
        {
        }

        public SuccessResponse(T data, string statusMessage, StatusCodeType statusCode) : base(data, true, statusMessage, statusCode)
        {
        }
    }
}
