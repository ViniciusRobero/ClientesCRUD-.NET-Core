using System.Collections.Generic;
using ClienteCRUD.Domain.Entities.Mapeamento;

namespace ClienteCRUD.Infra.Repositories.Interface
{
    public interface IClienteRepository
    {
        bool AdicionarCliente(Cliente Cliente);
        bool ExcluirCliente(int idCliente);
        List<Cliente> ListarClientes();
        bool AlterarCliente(Cliente Cliente);
        Cliente BuscarClientePorId(int idCliente);
    }
}
