using System;
using System.Collections.Generic;
using System.Text;
using ClienteCRUD.Domain.Entities.Mapeamento;
using ClienteCRUD.Domain.Interfaces;
using ClienteCRUD.Infra.Repositories.Interface;

namespace ClienteCRUD.Service.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository EnderecoRepository)
        {
            _enderecoRepository = EnderecoRepository;
        }

        public string AdicionarEndereco(Endereco endereco)
        {
            if(_enderecoRepository.AdicionarEndereco(endereco))
                return "Endereco cadastrado com sucesso.";

            return "Ocorreu um erro ao cadastrar o endereco.";
        }

        public string AlterarEndereco(Endereco endereco)
        {
            if (_enderecoRepository.AlterarEndereco(endereco))
                return "Endereco alterado com sucesso.";

            return "Ocorreu um erro ao alterado o endereco.";
        }

        public Endereco BuscarEnderecoPorId(int idEndereco)
        {
            throw new NotImplementedException();
        }

        public string ExcluirEndereco(int idEndereco)
        {
            if (_enderecoRepository.ExcluirEndereco(idEndereco))
                return "Endereco excluído com sucesso.";

            return "Ocorreu um erro ao excluído o endereco.";
        }

        public List<Endereco> ListarEnderecos()
        {
            return _enderecoRepository.ListarEnderecos();
        }
    }
}
