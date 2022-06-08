namespace LTunes.Lib.Shared.Models.Concrete
{
    public class Result : IResult
    {
        public Result()
        {
        }
        public Result(bool succeeded)
        {
            Succeeded = succeeded;
        }

        public Result(bool success, string statusMessage) : this(success)
        {
            StatusMessage = statusMessage;
        }

        public Result(bool success, string statusMessage, StatusCodeType statusCode) : this(success, statusMessage)
        {
            StatusCode = statusCode;
        }

        public bool Succeeded { get; set; }
        public StatusCodeType StatusCode { get; set; }
        public string StatusMessage { get; set; }
    }
}
