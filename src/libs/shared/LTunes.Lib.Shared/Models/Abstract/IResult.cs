namespace LTunes.Lib.Shared.Models.Abstract
{
    public interface IResult
    {
        bool Succeeded { get; set;  }
        string StatusMessage { get; set; }
        StatusCodeType StatusCode { get; set; }
    }
}
