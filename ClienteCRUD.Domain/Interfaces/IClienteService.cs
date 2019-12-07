using ClienteCRUD.Domain.Entities.Mapeamento;
using System.Collections.Generic;

namespace ClienteCRUD.Domain.Interfaces
{
    public interface IClienteService
    {
        string AdicionarCliente(Cliente Cliente);
        string ExcluirCliente(int idCliente);
        List<Cliente> ListarClientes();
        string AlterarCliente(Cliente Cliente);
        Cliente BuscarClientePorId(int idCliente);
    }
}
