using LTuınes.Lib.FileTransferProtocol.Services;

namespace LTuınes.Lib.FileTransferProtocol.IOC
{
    public static class ServiceCollectionContainerBuilderExtensions
    {
        public static void AddCdnSetting(this IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
            services.Configure<CdnSetting>(configuration.GetRequiredSection(nameof(CdnSetting)));
            services.TryAddSingleton<ICdnSetting>(provider =>
            {
                var cdnSetting = provider.GetRequiredService<IOptions<CdnSetting>>().Value;
                return new CdnSetting(cdnSetting.Url, Guid.NewGuid().ToString());
            });

            serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            ICdnSetting cdnSetting = serviceProvider.GetRequiredService<ICdnSetting>();
            if (cdnSetting.CheckIfClassPropertiesEmptyOrNull())
                throw new ArgumentException(ExceptionMessage.CDNSettingRequired);
        }

        public static void AddFtpService(this IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
            services.Configure<FtpSetting>(configuration.GetRequiredSection(nameof(FtpSetting)));
            services.TryAddSingleton<IFtpSetting>(provider => provider.GetRequiredService<IOptions<FtpSetting>>().Value);

            serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            IFtpSetting ftpSetting = serviceProvider.GetRequiredService<IFtpSetting>();
            if (ftpSetting.CheckIfClassPropertiesEmptyOrNull())
                throw new ArgumentException(ExceptionMessage.FtpSettingRequired);

            services.TryAddScoped<IFileTransferProtocolService, FileTransferProtocolManager>();
        }
    }
}
