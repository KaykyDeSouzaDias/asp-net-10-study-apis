using Scalar.AspNetCore;

namespace ApiStudy.Configurations
{
    public static class ScalarConfig
    {
        private static readonly string AppName = "ApiStudy";

        public static WebApplication UseScalarSpecification(this WebApplication app)
        {
            app.MapScalarApiReference("/scalar", options =>
            {
                options
                    .WithTitle(AppName)
                    .WithOpenApiRoutePattern("/swagger/v1/swagger.json");
            });

            return app;
        }
    }
}
