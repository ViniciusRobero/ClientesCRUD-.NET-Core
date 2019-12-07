using ClienteCRUD.Domain.Entities.Mapeamento;
using System.Collections.Generic;

namespace ClienteCRUD.Infra.Repositories.Interface
{
    public interface IEnderecoRepository
    {
        bool AdicionarEndereco(Endereco Endereco);
        bool ExcluirEndereco(int idEndereco);
        Endereco BuscarEnderecoPorId(int idEndereco);
        bool AlterarEndereco(Endereco Endereco);
        List<Endereco> ListarEnderecos();
    }
}
