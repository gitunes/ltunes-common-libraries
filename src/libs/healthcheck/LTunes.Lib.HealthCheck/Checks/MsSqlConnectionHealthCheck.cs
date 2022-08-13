namespace LTunes.Lib.HealthCheck.Checks
{
    internal static class MsSqlConnectionHealthCheck
    {
        internal static IHealthChecksBuilder AddMsSqlDatabaseChecks(this IHealthChecksBuilder healthChecksBuilder, IConfiguration configuration)
        {
            string healthSqlQuery = "Select 1;";

            string databaseConnectionString = configuration.GetValue<string>("ConnectionStrings");
            if (!string.IsNullOrWhiteSpace(databaseConnectionString))
            {
                healthChecksBuilder.AddSqlServer(
                   connectionString: databaseConnectionString,
                   healthQuery: healthSqlQuery,
                   name: "[MS SQL] - Veri Tabanı",
                   failureStatus: HealthStatus.Unhealthy,
                   tags: new[] { "MSSQL Server", "DbContext", "Authentication" });
            }

            string comDogusOtoTyreShopDbContext = configuration.GetValue<string>("ConnectionStrings");
            if (!string.IsNullOrWhiteSpace(databaseConnectionString))
            {
                healthChecksBuilder.AddSqlServer(
                   connectionString: comDogusOtoTyreShopDbContext,
                   healthQuery: healthSqlQuery,
                   name: "[MS SQL] - Veri Tabanı",
                   failureStatus: HealthStatus.Unhealthy,
                   tags: new[] { "MSSQL Server", "DbContext", "DBName" });
            }

            return healthChecksBuilder;
        }
    }
}
