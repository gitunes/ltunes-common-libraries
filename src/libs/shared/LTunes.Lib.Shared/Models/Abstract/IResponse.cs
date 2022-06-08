namespace LTunes.Lib.Shared.Models.Abstract
{
    public interface IResponse<out T> : IResult
    {
        T Data { get; }
    }
}
