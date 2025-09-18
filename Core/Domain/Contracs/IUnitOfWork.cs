using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls;

namespace Domain.Contracs
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChanges();
        public IGenericReposatory<TEntity, Tkey> GenericReposatory<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;
    }
}
