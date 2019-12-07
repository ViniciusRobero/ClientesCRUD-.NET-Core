using ClienteCRUD.Domain.Entities.Mapeamento;
using System.Collections.Generic;

namespace ClienteCRUD.Domain.Interfaces
{
    public interface IEnderecoService
    {
        string AdicionarEndereco(Endereco endereco);
        string ExcluirEndereco(int idEndereco);
        Endereco BuscarEnderecoPorId(int idEndereco);
        string AlterarEndereco(Endereco endereco);
        List<Endereco> ListarEnderecos();
    }
}
