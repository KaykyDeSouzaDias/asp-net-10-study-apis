using Microsoft.OpenApi;

namespace ApiStudy.Configurations
{
    public static class OpenAPIConfig
    {
        private static readonly string AppName = "ApiStudy";
        private static readonly string AppDescription = $"{AppName} API";

        public static IServiceCollection AddOpenAPIConfig(
            this IServiceCollection services)
        {
            services.AddSingleton(new OpenApiInfo
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

            return services;
        }
    }
}
