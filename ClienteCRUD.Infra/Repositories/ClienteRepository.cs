using ClienteCRUD.Domain.Entities.Mapeamento;
using ClienteCRUD.Infra.Context;
using ClienteCRUD.Infra.Repositories.Interface;
using ClienteCRUD.Infra.Standard;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ClienteCRUD.Infra.Repositories
{
    public class ClienteRepository : DomainRepository<Cliente>, IClienteRepository
    {
        private readonly DbSet<Cliente> _cliente;

        public ClienteRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _cliente = dbContext.Set<Cliente>();
        }

        public bool AdicionarCliente(Cliente Cliente)
        {
            try
            {
                _cliente.Add(Cliente);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ExcluirCliente(int idCliente)
        {
            try
            {
                var Cliente = _cliente.SingleOrDefault(x => x.Id == idCliente);

                if (Cliente != null)
                {
                    _cliente.Remove(Cliente);
                    dbContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public Cliente BuscarClientePorId(int idCliente)
        {
            try
            {
                return _cliente
                    .SingleOrDefault(x => x.Id == idCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Cliente> ListarClientes()
        {
            try
            {
                return _cliente
                    .Include(x => x.Endereco)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AlterarCliente(Cliente Cliente)
        {
            try
            {
                _cliente.Update(Cliente);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
