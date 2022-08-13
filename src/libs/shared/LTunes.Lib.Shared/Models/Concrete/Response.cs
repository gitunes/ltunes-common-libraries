namespace LTunes.Lib.Shared.Models.Concrete
{
    public class Response<T> : Result, IResponse<T>
    {
        public Response(bool succeeded) : base(succeeded)
        {
        }

        public Response(T data, bool succeeded) : base(succeeded)
        {
            Data = data;
        }

        public Response(T data, bool succeeded, string statusMessage) : base(succeeded, statusMessage)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
