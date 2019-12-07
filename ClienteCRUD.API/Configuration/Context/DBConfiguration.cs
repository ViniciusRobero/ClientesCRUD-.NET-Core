using ClienteCRUD.Infra.Context;
using ClienteCRUD.Infra.DBConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClienteCRUD.API.Configuration.Context
{
    public static class DBConfiguration
    {
        public static void Register(this IServiceCollection services)
        {
            IConfiguration _configuration = DatabaseConnection.ConnectionConfiguration;
            var conn = _configuration.GetConnectionString("SQLExpressConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(conn));
        }
    }
}
