using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ClienteCRUD.Domain.Entities.Mapeamento;
using ClienteCRUD.Infra.Context;
using ClienteCRUD.Infra.Repositories.Interface;
using ClienteCRUD.Infra.Standard;
using System;

namespace ClienteCRUD.Infra.Repositories
{
    public class EnderecoRepository : DomainRepository<Endereco>, IEnderecoRepository
    {
        private readonly DbSet<Endereco> _endereco;

        public EnderecoRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _endereco = dbContext.Set<Endereco>();
        }

        public bool AdicionarEndereco(Endereco endereco)
        {
            try
            {
                _endereco.Add(endereco);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ExcluirEndereco(int idEndereco)
        {
            try
            {
                var Endereco = _endereco.SingleOrDefault(x => x.Id == idEndereco);

                if (Endereco != null)
                {
                    _endereco.Remove(Endereco);
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

        public Endereco BuscarEnderecoPorId(int idEndereco)
        {
            try
            {
                return _endereco
                    .SingleOrDefault(x => x.Id == idEndereco);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Endereco> ListarEnderecos()
        {
            try
            {
                return _endereco.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AlterarEndereco(Endereco Endereco)
        {
            try
            {
                _endereco.Update(Endereco);
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
