namespace LTunes.Lib.Shared.Services
{
    /// <summary>
    /// It provides the management of business rules in the code from a single central point.
    /// </summary>
    public static class ServiceManager
    {
        public static IResult Run(params IResult[] logics)
        {
            return logics.FirstOrDefault(logic => !logic.Succeeded);
        }
    }
}