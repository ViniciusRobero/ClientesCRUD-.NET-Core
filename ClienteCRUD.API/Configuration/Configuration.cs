using ClienteCRUD.API.Configuration.Context;
using ClienteCRUD.API.Configuration.Cors;
using ClienteCRUD.API.Configuration.DependencyInjection;
using ClienteCRUD.API.Configuration.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClienteCRUD.API.Configuration
{
    public static class Configuration
    {
        public static void AddConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            DBConfiguration.Register(service);
            RepositoriesDI.Register(service);
            ServicesDI.Register(service);
            CorsConfiguration.RegisterCors(service);
            SwaggerConfiguration.RegisterSwagger(service);
        }
    }
}
