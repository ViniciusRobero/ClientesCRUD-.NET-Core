using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteCRUD.Infra.Standard
{
    public interface IDomainRepository<TEntity> : IDisposable where TEntity : class
    {}
}
