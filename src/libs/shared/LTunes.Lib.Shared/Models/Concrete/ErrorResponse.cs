namespace LTunes.Lib.Shared.Models.Concrete
{
    public sealed class ErrorResponse<T> : Response<T>
    {
        public ErrorResponse() : base(default, false, ExceptionMessage.AnUnspecifiedErrorHasOccurred)
        {
        }

        public ErrorResponse(string statusMessage) : base(default, false, statusMessage)
        {
        }
    }
}
