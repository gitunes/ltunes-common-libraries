namespace LTunes.Lib.Shared.Services
{
    /// <summary>
    /// It provides the management of business rules in the code from a single central point.
    /// </summary>
    public static class ServiceManager
    {
        public static IResult Run(params IResult[] logics)
        {
            var result = logics.FirstOrDefault(logic => !logic.Succeeded);
            if (result is not null)
                return result;

            return logics.Last();
        }
    }
}