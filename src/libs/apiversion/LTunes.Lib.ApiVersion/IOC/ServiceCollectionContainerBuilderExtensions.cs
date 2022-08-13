namespace LTunes.Lib.ApiVersion.IOC
{
    public static class ServiceCollectionContainerBuilderExtensions
    {
        /// <summary>
        /// Add api versioning with provider
        /// </summary>
        /// <param name="services">type of built-in service collection interface</param>
        /// <param name="defaultErrorResponseProvider">default error response provider</param>
        /// <seealso cref="https://github.com/dotnet/aspnet-api-versioning"/>
        /// <returns>type of built-in service collection interface</returns>
        /// <exception cref="ArgumentNullException">when the service provider cannot be built</exception>
        /// <exception cref="InvalidOperationException">if your application settings file does not contain api version configurations</exception>
        public static IServiceCollection AddApiVersioningWithProvider(this IServiceCollection services, DefaultErrorResponseProvider defaultErrorResponseProvider = null)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
            services.Configure<ApiVersionSetting>(configuration.GetRequiredSection(nameof(ApiVersionSetting)));
            services.TryAddSingleton<IApiVersionSetting>(provider => provider.GetRequiredService<IOptions<ApiVersionSetting>>().Value);

            serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            IApiVersionSetting apiVersionSetting = serviceProvider.GetService<IApiVersionSetting>();
            if (apiVersionSetting is null)
                throw new SettingException(ExceptionMessage.ApiVersionSettingRequired);

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new(apiVersionSetting.MajorVersion, apiVersionSetting.MinorVersion);
                options.ReportApiVersions = true;
                options.ApiVersionReader = new HeaderApiVersionReader(apiVersionSetting.HeaderName);

                if (defaultErrorResponseProvider is not null)
                {
                    options.ErrorResponses = defaultErrorResponseProvider;
                }
            });

            return services;
        }
    }
}
