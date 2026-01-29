using Microsoft.Net.Http.Headers;

namespace ApiStudy.Configurations
{
    public static class ContentNegociationConfig
    {
        public static IMvcBuilder AddContentNegociation(
            this IMvcBuilder builder)
        {
            return builder.AddMvcOptions(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.ReturnHttpNotAcceptable = true;

                options.FormatterMappings.SetMediaTypeMappingForFormat(
                    "xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat(
                    "json", MediaTypeHeaderValue.Parse("application/json"));
            }).AddXmlSerializerFormatters();
        }
    }
}
