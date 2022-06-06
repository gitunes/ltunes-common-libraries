namespace DogusOto.Lib.Documentation.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Add swagger configuration
        /// </summary>
        /// <param name="app">type of built-in application builder interface</param>
        /// <param name="isClosedSchema">is closed schema</param>
        /// <returns>type of built-in application builder interface</returns>
        /// <exception cref="ArgumentNullException">when there are no settings for swagger</exception>
        /// <exception cref="InvalidOperationException">If the container cannot invoke the web host environment interface</exception>
        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, bool isClosedSchema = true)
        {
            IWebHostEnvironment webHostEnvironment = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
            if (webHostEnvironment.IsProduction())
                return app;

            ISwaggerSetting swaggerSetting = app.ApplicationServices.GetRequiredService<ISwaggerSetting>();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", swaggerSetting.DefinitionName);
                options.RoutePrefix = string.Empty;

                if (isClosedSchema)
                {
                    options.DefaultModelsExpandDepth(-1);
                }
            });

            return app;
        }

        /// <summary>
        /// Add redocly configuration
        /// </summary>
        /// <param name="app">type of built-in application builder interface</param>
        /// <returns>type of built-in application builder interface</returns>
        /// <exception cref="ArgumentNullException">when there are no settings for swagger</exception>
        /// <exception cref="InvalidOperationException">If the container cannot invoke the web host environment interface</exception>
        public static IApplicationBuilder UseRedoclyConfiguration(this IApplicationBuilder app)
        {
            IWebHostEnvironment webHostEnvironment = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
            if (webHostEnvironment.IsProduction())
                return app;

            ISwaggerSetting swaggerSetting = app.ApplicationServices.GetRequiredService<ISwaggerSetting>();

            app.UseReDoc(options =>
            {
                options.DocumentTitle = swaggerSetting.Title;
                options.SpecUrl = "/swagger/v1/swagger.json";
            });

            return app;
        }
    }
}
