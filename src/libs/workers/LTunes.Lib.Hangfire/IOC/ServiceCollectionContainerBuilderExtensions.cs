namespace LTunes.Lib.Hangfire.IOC
{
    public static class ServiceCollectionContainerBuilderExtensions
    {
        /// <summary>
        /// Add hangfire with sql server storage
        /// </summary>
        /// <param name="services">type of built-in service collection interface</param>
        /// <seealso cref="https://www.hangfire.io/"/>
        /// <returns>type of built-in service collection interface</returns>
        /// <exception cref="ArgumentNullException">when the service provider cannot be built</exception>
        /// <exception cref="InvalidOperationException">if your application settings file does not contain hangfire configurations</exception>
        public static IServiceCollection AddHangfireWithSqlServerStorage(this IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
            services.Configure<HangfireSetting>(configuration.GetRequiredSection(nameof(HangfireSetting)));
            services.TryAddSingleton<IHangfireSetting>(provider => provider.GetRequiredService<IOptions<HangfireSetting>>().Value);

            serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            IHangfireSetting hangfireSetting = serviceProvider.GetRequiredService<IHangfireSetting>();
            if (hangfireSetting.CheckIfClassPropertiesEmptyOrNull())
                throw new ArgumentNullException(nameof(hangfireSetting), ExceptionMessage.HangfireSettingRequired);

            SqlServerStorageOptions options = new()
            {
                PrepareSchemaIfNecessary = true,
                QueuePollInterval = TimeSpan.FromMinutes(hangfireSetting.QueuePollIntervalMinute),
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5)
            };

            services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(hangfireSetting.ConnectionString, options)
                                  .WithJobExpirationTimeout(TimeSpan.FromDays(hangfireSetting.JobExpirationTimeoutDay));
            });

            services.AddHangfireServer();

            return services;
        }
    }
}
