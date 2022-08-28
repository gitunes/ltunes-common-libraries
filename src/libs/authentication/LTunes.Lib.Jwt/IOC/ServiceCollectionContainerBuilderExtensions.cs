namespace LTunes.Lib.Jwt.IOC
{
    public static class ServiceCollectionContainerBuilderExtensions
    {
        /// <summary>
        /// Add jwt authentication
        /// </summary>
        /// <param name="services">type of built-in service collection interface</param>
        /// <param name="isHaveJwtBearerEvents">is have jwt bearer events?</param>
        /// <returns>type of built-in service collection interface</returns>
        /// <seealso cref="https://jwt.io/"/>
        /// <exception cref="ArgumentNullException">when the service provider cannot be built</exception>
        /// <exception cref="InvalidOperationException">if your application settings file does not contain jwt configurations</exception>
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, bool isHaveJwtBearerEvents = false)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
            services.Configure<TokenOptionsSetting>(configuration.GetRequiredSection(nameof(TokenOptionsSetting)));
            services.TryAddSingleton<ITokenOptionsSetting>(provider => provider.GetRequiredService<IOptions<TokenOptionsSetting>>().Value);

            serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            ITokenOptionsSetting tokenOptionsSetting = serviceProvider.GetRequiredService<ITokenOptionsSetting>();
            if (tokenOptionsSetting.CheckIfClassPropertiesEmptyOrNull())
                throw new SettingException(ExceptionMessage.TokenOptionsSettingRequired);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, configureOptions =>
            {
                configureOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = tokenOptionsSetting.Issuer,
                    ValidAudience = tokenOptionsSetting.Audiences[0],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptionsSetting.SecurityKey)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };

                if (isHaveJwtBearerEvents)
                {
                    configureOptions.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            string accessToken = context.Request.Query[AuthenticationParameters.AccessToken];
                            PathString path = context.HttpContext.Request.Path;

                            if (!string.IsNullOrEmpty(accessToken))
                            {
                                context.Token = accessToken;
                            }

                            return Task.CompletedTask;
                        }
                    };
                }
            });

            return services;
        }

        /// <summary>
        /// Add claim service
        /// </summary>
        /// <param name="services">type of built-in service collection interface</param>
        /// <seealso cref="https://docs.microsoft.com/en-us/aspnet/core/security/authorization/claims?view=aspnetcore-6.0"/>
        /// <returns>type of built-in service collection interface</returns>
        public static IServiceCollection AddClaimService(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IClaimService, ClaimManager>();

            return services;
        }
    }
}
