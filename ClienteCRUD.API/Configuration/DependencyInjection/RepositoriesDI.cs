using ClienteCRUD.Infra.Repositories;
using ClienteCRUD.Infra.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace ClienteCRUD.API.Configuration.DependencyInjection
{
    public static class RepositoriesDI
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        }
    }
}
