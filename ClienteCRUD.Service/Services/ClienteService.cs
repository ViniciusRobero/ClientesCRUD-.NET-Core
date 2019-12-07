
using ClienteCRUD.Domain.Entities.Mapeamento;
using ClienteCRUD.Domain.Interfaces;
using ClienteCRUD.Infra.Repositories.Interface;
using System;
using System.Collections.Generic;

namespace ClienteCRUD.Service.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository ClienteRepository)
        {
            _clienteRepository = ClienteRepository;
        }

        public string AdicionarCliente(Cliente Cliente)
        {
            if (CPFValido(Cliente.CPF))
                return "O CPF do cliente está inválido.";

            if (DataNascimentoInvalida(Cliente.DataNascimento))
                return "A data de nascimento não pode ser maior que a data atual.";

            if (_clienteRepository.AdicionarCliente(Cliente))
                return "Cliente cadastrado com sucesso.";

            return "Ocorreu um erro ao cadastrar o cliente.";
        }

        public string AlterarCliente(Cliente Cliente)
        {
            if (_clienteRepository.AlterarCliente(Cliente))
                return "Usuário alterado com sucesso";

            return "Ocorreu um erro ao alterar o cliente.";
        }

        public string ExcluirCliente(int idCliente)
        {
            if (_clienteRepository.ExcluirCliente(idCliente))
                return "Cliente excluído com sucesso";

            return "Ocorreu um erro ao excluir o cliente.";
        }

        public List<Cliente> ListarClientes()
        {
            return _clienteRepository.ListarClientes();
        }

        public Cliente BuscarClientePorId(int idCliente)
        {
            return _clienteRepository.BuscarClientePorId(idCliente);
        }

        #region Validacoes
        private bool CPFValido(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);

        }

        private bool DataNascimentoInvalida(DateTime dataNascimento)
        {
            return DateTime.Today < dataNascimento.Date;
        }
        #endregion
    }
}

