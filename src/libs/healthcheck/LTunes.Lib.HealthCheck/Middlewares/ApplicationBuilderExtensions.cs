namespace LTunes.Lib.HealthCheck.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Use health check
        /// </summary>
        /// <param name="app">type of built-in application builder interface</param>
        /// <returns>type of built-in application builder interface</returns>
        /// <exception cref="InvalidOperationException">if your application settings file does not contain health check common configurations</exception>
        public static IApplicationBuilder UseHealthCheck(this IApplicationBuilder app, bool isCustomStyle = true)
        {
            IWebHostEnvironment webHostEnvironment = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
            if (webHostEnvironment.IsLocalhost())
                return app;

            IHealthChecksCommonSetting healthChecksCommonSetting = app.ApplicationServices.GetRequiredService<IHealthChecksCommonSetting>();
            app.UseHealthChecks(healthChecksCommonSetting.ResponseUrl, new HealthCheckOptions
            {
                Predicate = _ => true,
                AllowCachingResponses = false,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                ResultStatusCodes =
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status200OK,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                }
            });

            app.UseHealthChecksUI(setup =>
            {
                setup.UIPath = healthChecksCommonSetting.ViewUrl;

                if (isCustomStyle && !webHostEnvironment.IsLocalhost())
                {
                    setup.AddCustomStylesheet(Path.Combine(Directory.GetCurrentDirectory(), healthChecksCommonSetting.CustomCssUrl));
                }
            });

            return app;
        }
    }
}
