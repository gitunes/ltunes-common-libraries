namespace LTunes.Lib.Shared.Models.Concrete
{
    public sealed class ErrorResult : Result
    {
        public ErrorResult() : base(false, Message.AnUnspecifiedErrorHasOccurred, StatusCodeType.Exception)
        {
        }

        public ErrorResult(string statusMessage) : base(false, statusMessage, StatusCodeType.Exception)
        {
        }
    }
}
