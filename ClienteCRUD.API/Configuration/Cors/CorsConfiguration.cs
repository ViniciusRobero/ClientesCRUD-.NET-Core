using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCRUD.API.Configuration.Cors
{
    public static class CorsConfiguration
    {
        public static void RegisterCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("origins",
                builder =>
                {
                    builder.AllowAnyMethod()
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials()
                    .AllowAnyHeader();
                });
            });
        }
    }
}
