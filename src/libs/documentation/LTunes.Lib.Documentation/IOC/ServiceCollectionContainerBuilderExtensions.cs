namespace LTunes.Lib.Documentation.IOC
{
    public static class ServiceCollectionContainerBuilderExtensions
    {
        /// <summary>
        /// Add swagger documentation
        /// </summary>
        /// <param name="services">type of built-in service collection interface</param>
        /// <param name="isJwtSecurityScheme">is jwt security scheme</param>
        /// <param name="isBasicSecurityScheme">is basic security scheme</param>
        /// <seealso cref="https://swagger.io/"/>
        /// <returns>type of built-in service collection interface</returns>
        /// <exception cref="ArgumentNullException">when the service provider cannot be built</exception>
        /// <exception cref="InvalidOperationException">if your application settings file does not contain swagger configurations</exception>
        public static IServiceCollection AddSwagger(this IServiceCollection services, bool isJwtSecurityScheme = false, bool isBasicSecurityScheme = false)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
            services.Configure<SwaggerSetting>(configuration.GetRequiredSection(nameof(SwaggerSetting)));
            services.TryAddSingleton<ISwaggerSetting>(provider => provider.GetRequiredService<IOptions<SwaggerSetting>>().Value);

            serviceProvider = services.BuildServiceProvider();
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            ISwaggerSetting swaggerSetting = serviceProvider.GetRequiredService<ISwaggerSetting>();
            if (swaggerSetting.CheckIfClassPropertiesEmptyOrNull())
                throw new SettingException(ExceptionMessage.SwaggerSettingRequired);

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(swaggerSetting.Version,
                    new()
                    {
                        Title = swaggerSetting.Title,
                        Description = swaggerSetting.Description,
                        Version = swaggerSetting.Version,
                        Contact = new()
                        {
                            Email = swaggerSetting.ContactEmail,
                            Name = swaggerSetting.ContactName,
                            Url = new(swaggerSetting.ContactUrl)
                        },
                        License = new()
                        {
                            Name = swaggerSetting.LicenseName,
                            Url = new(swaggerSetting.LicenseUrl)
                        },
                        Extensions = new Dictionary<string, IOpenApiExtension>
                        {
                          {"x-logo", new OpenApiObject
                           {
                              {"url", new OpenApiString("https://www.d-teknoloji.com.tr/assets/img/logo.png")}
                           }
                          }
                        }
                    });

                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                if (isJwtSecurityScheme)
                {
                    OpenApiSecurityScheme jwtSecurityScheme = new()
                    {
                        In = ParameterLocation.Header,
                        Name = HeaderNames.Authorization,
                        Type = SecuritySchemeType.Http,
                        Description = "Bearer {token}",
                        BearerFormat = "JWT",
                        Scheme = "bearer",
                        Reference = new()
                        {
                            Id = JwtBearerDefaults.AuthenticationScheme,
                            Type = ReferenceType.SecurityScheme

                        }
                    };

                    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, jwtSecurityScheme);
                    options.AddSecurityRequirement(new()
                    {
                        { jwtSecurityScheme, Array.Empty<string>() }
                    });
                }

                if (isBasicSecurityScheme)
                {
                    OpenApiSecurityScheme basicSecurityScheme = new()
                    {
                        Type = SecuritySchemeType.Http,
                        Scheme = "basic",
                        Reference = new()
                        {
                            Id = "BasicAuth",
                            Type = ReferenceType.SecurityScheme
                        }
                    };

                    options.AddSecurityDefinition(basicSecurityScheme.Reference.Id, basicSecurityScheme);
                    options.AddSecurityRequirement(new()
                    {
                        { basicSecurityScheme, Array.Empty<string>() },
                    });
                }
            });

            return services;
        }
    }
}
