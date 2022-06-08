namespace LTunes.Lib.Shared.Models.Concrete
{
    public sealed class ApiResponse<T> : IResponse<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string StatusMessage { get; set; }
        public StatusCodeType StatusCode { get; set; }
    }

    public sealed class ApiResponse : IResult
    {
        public bool Succeeded { get; set; }
        public string StatusMessage { get; set; }
        public StatusCodeType StatusCode { get; set; }
    }
}
