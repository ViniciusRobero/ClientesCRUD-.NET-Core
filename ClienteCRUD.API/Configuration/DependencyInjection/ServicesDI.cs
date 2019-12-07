using ClienteCRUD.Domain.Interfaces;
using ClienteCRUD.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClienteCRUD.API.Configuration.DependencyInjection
{
    public static class ServicesDI
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
        }
    }
}
