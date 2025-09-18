using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls;

namespace Domain.Contracs
{
    public interface IGenericReposatory<TEntity,TKey>where TEntity : BaseEntity<TKey>
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity> GetByIdAsync(TKey id);
        public void Delete(TEntity entity);
        public void Update(TEntity entity);
        public Task Add(TEntity entity);
    }
}
