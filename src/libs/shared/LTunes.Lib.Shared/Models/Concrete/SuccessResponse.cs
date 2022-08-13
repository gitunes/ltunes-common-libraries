namespace LTunes.Lib.Shared.Models.Concrete
{
    public class SuccessResponse<T> : Response<T>
    {
        public SuccessResponse() : base(default, true, SuccessMessage.TransactionSuccessful)
        {
        }

        public SuccessResponse(string message) : base(default, true, message)
        {
        }

        public SuccessResponse(T data) : base(data, true, SuccessMessage.TransactionSuccessful)
        {
        }

        public SuccessResponse(T data, string statusMessage) : base(data, true, statusMessage)
        {
        }
    }
}
