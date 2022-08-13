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

        public bool Succeeded { get; set; }
        public string StatusMessage { get; set; }
    }
}
