namespace LTunes.Lib.HealthCheck.Checks
{
    internal static class HangfireConnectionHealthCheck
    {
        internal static IHealthChecksBuilder AddHangfireCheck(this IHealthChecksBuilder healthChecksBuilder)
        {
            healthChecksBuilder.AddHangfire(setup =>
            {
                setup.MaximumJobsFailed = 3;
                setup.MinimumAvailableServers = 1;
            },
               name: "[Hangfire] - Zamanlanmış İşler",
               failureStatus: HealthStatus.Unhealthy,
               tags: new[] { "Schedule Task", "Cron", "Jobs" });

            return healthChecksBuilder;
        }
    }
}
