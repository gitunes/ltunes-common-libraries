namespace LTunes.Lib.Shared.Models.Concrete
{
    public sealed class SuccessResult : Result
    {
        public SuccessResult() : base(true, SuccessMessage.TransactionSuccessful)
        {
        }

        public SuccessResult(string statusMessage) : base(true, statusMessage)
        {
        }
    }
}
