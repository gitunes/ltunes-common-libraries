namespace LTunes.Lib.HealthCheck.Checks
{
    internal static class ServiceConnectionHealthCheck
    {
        internal static IHealthChecksBuilder AddServicesCheck(this IHealthChecksBuilder healthChecksBuilder, IServiceProvider serviceProvider)
        {
            IHealthChecksSettings healthChecksSettings = serviceProvider.GetRequiredService<IHealthChecksSettings>();
            if (healthChecksSettings.CheckIfClassPropertiesEmptyOrNull())
                throw new SettingException(ExceptionMessage.HealthChecksSettingsRequired);

            foreach (var service in healthChecksSettings.UrlGroupSettings)
            {
                healthChecksBuilder.AddUrlGroup(
                    uri: service.Url,
                    name: service.Name,
                    failureStatus: HealthStatus.Unhealthy,
                    tags: service.Tags);
            }

            return healthChecksBuilder;
        }
    }
