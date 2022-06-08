namespace LTunes.Lib.Shared.Models.Concrete
{
    public sealed class SuccessResult : Result
    {
        public SuccessResult() : base(true, Message.Success, StatusCodeType.Success)
        {
        }
    }
}
