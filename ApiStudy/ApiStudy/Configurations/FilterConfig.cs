using Microsoft.AspNetCore.Mvc;

namespace ApiStudy.Configurations
{
    public static class FilterConfig
    {
        public static IServiceCollection AddFilterConfig(
           this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(new ConsumesAttribute("application/json"));
            });

            return services;
        }
    }
}
