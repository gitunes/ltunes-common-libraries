namespace LTunes.Lib.Hangfire.Abstract
{
    public interface IJobManager
    {
    }

    public interface IFireAndForgotManager : IJobManager
    {
    }

    public interface IDelayedJobManager : IJobManager
    {
    }

    public interface IRecurringJobManager : IJobManager
    {
    }

    public interface IContinuationJobManagers : IJobManager
    {
    }
}
