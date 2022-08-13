namespace LTunes.Lib.Shared.Utilities
{
    public static class HostEnvironmentExtensions
    {
        public static bool IsLocalhost(this IHostEnvironment hostEnvironment) => hostEnvironment.IsEnvironment("Localhost");
    }
}
