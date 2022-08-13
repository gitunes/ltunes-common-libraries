namespace LTunes.Lib.Shared.Models.Concrete
{
    public sealed class ErrorResult : Result
    {
        public ErrorResult() : base(false, ExceptionMessage.AnUnspecifiedErrorHasOccurred)
        {
        }

        public ErrorResult(string statusMessage) : base(false, statusMessage)
        {
        }
    }
}
