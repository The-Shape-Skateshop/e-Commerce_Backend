using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace e_Commerce.API.Config.ExtensionMethods
{
    public static class SwaggerConfigExtension
    {
        public static void ConfigurarSwaggerExtension(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.MapType<DateTime>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("2023-11-20")
                });
            });
        }
    }
}
