namespace LTunes.Lib.HealthCheck.Checks
{
    internal static class SystemConfigurationHealthCheck
    {
        internal static IHealthChecksBuilder AddSystemConfigurationCheck(this IHealthChecksBuilder healthChecksBuilder)
        {
            healthChecksBuilder.AddDiskStorageHealthCheck(setup =>
            {
                setup.AddDrive(@"C:\", 2048);

            },
            name: "[Sunucu] - Disk Kapasitesi",
            failureStatus: HealthStatus.Unhealthy,
            tags: new[] { "Server", "Storage", "Capacity" });

            healthChecksBuilder.AddProcessAllocatedMemoryHealthCheck(
                name: "[Sunucu] - Ayrılan Bellek Kapasitesi",
                maximumMegabytesAllocated: 2048,
                tags: new[] { "Server", "Process", "Memory" });

            return healthChecksBuilder;
        }
    }
}
