namespace LTunes.Lib.Shared.Models.Concrete
{
    public sealed class ErrorResponse<T> : Response<T>
    {
        public ErrorResponse() : base(default, false, Message.AnUnspecifiedErrorHasOccurred, StatusCodeType.Exception)
        {
        }

        public ErrorResponse(StatusCodeType statusCode) : base(default, false, Message.AnUnspecifiedErrorHasOccurred, statusCode)
        {
        }

        public ErrorResponse(string statusMessage) : base(default, false, statusMessage, StatusCodeType.Exception)
        {
        }

        public ErrorResponse(StatusCodeType statusCode, string statusMessage) : base(default, false, statusMessage, statusCode)
        {
        }

        public ErrorResponse(T data, StatusCodeType statusCode) : base(data, false, Message.AnUnspecifiedErrorHasOccurred, statusCode)
        {
        }

        public ErrorResponse(T data, string statusMessage) : base(data, false, statusMessage, StatusCodeType.Exception)
        {
        }

        public ErrorResponse(T data, string statusMessage, StatusCodeType statusCode) : base(data, false, statusMessage, statusCode)
        {
        }
    }
}
