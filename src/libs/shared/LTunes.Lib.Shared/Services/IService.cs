namespace LTunes.Lib.Shared.Services
{
    public interface IService
    {
    }

    public interface ISingletonService : IService
    {
    }

    public interface IScopedService : IService
    {
    }

    public interface ITransientService : IService
    {
    }
}
