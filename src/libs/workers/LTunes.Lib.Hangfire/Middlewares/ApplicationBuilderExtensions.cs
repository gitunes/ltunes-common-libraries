namespace LTunes.Lib.Hangfire.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Use hangfire
        /// </summary>
        /// <param name="app">type of built-in application builder interface</param>
        /// <returns>type of built-in application builder interface</returns>
        /// <exception cref="ArgumentNullException">when hangfire settings not found</exception>
        /// <exception cref="InvalidOperationException">if your application settings file does not contain hangfire configurations</exception>
        public static IApplicationBuilder UseHangfire(this IApplicationBuilder app)
        {
            IHangfireSetting hangfireSetting = app.ApplicationServices.GetRequiredService<IHangfireSetting>();
            if (hangfireSetting.CheckIfClassPropertiesEmptyOrNull())
                throw new ArgumentNullException(nameof(hangfireSetting), ExceptionMessage.HangfireSettingRequired);

            app.UseHangfireDashboard(hangfireSetting.DashboardPath, new DashboardOptions
            {
                DashboardTitle = hangfireSetting.DashboardTitle,
                AppPath = hangfireSetting.BackButtonPath,
                Authorization = new[] { new HangfireCustomBasicAuthenticationFilter
                {
                    User = hangfireSetting.Username,
                    Pass = hangfireSetting.Password
                } },
                IgnoreAntiforgeryToken = true
            });

            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = hangfireSetting.GlobalAutomaticRetryAttempts });
            GlobalConfiguration.Configuration.UseActivator(new HangfireActivator(app.ApplicationServices));

            return app;
        }
    }
}
