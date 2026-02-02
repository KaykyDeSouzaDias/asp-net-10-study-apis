using Microsoft.OpenApi;

namespace ApiStudy.Configurations
{
    public static class SwaggerConfig
    {
        private static readonly string AppName = "ApiStudy";
        private static readonly string AppDescription = $"{AppName} API";

        public static IServiceCollection AddSwaggerConfig(
            this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = AppName,
                    Version = "v1",
                    Description = AppDescription,
                    Contact = new OpenApiContact
                    {
                        Name = "Kayky Dias",
                        Url = new Uri("https://github.com/KaykyDeSouzaDias")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });

                options.CustomSchemaIds(type => type.FullName);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerSpecification(
            this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = "swagger-ui";
                options.DocumentTitle = $"{AppName} API Documentation";
            });
            return app;
        }
    }
}
