namespace LTunes.Lib.HealthCheck.Checks
{
    internal static class RedisConnectionHealthCheck
    {
        internal static IHealthChecksBuilder AddRedisCheck(this IHealthChecksBuilder healthChecksBuilder, IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>("RedisServerSetting:ConnectionString");
            string username = configuration.GetValue<string>("RedisServerSetting:Username");
            string password = configuration.GetValue<string>("RedisServerSetting:Password");

            if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return healthChecksBuilder;

            healthChecksBuilder.AddRedis(
                   redisConnectionString: $"{connectionString},user={username},password={password}",
                   name: "[Redis] - Veri Tabanı",
                   failureStatus: HealthStatus.Unhealthy,
                   tags: new[] { "Cache", "NoSQL", "Database" });

            return healthChecksBuilder;
        }
    }
}
