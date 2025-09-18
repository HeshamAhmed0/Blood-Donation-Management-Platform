using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracs;
using Domain.Meduls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Persistence.DbContexts;

namespace Persistence.Reposatories
{
    public class GenericReposatory<TEntity, TKey> : IGenericReposatory<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly BloodDonationDbContext bloodDonationDbContext;

        public GenericReposatory(BloodDonationDbContext bloodDonationDbContext)
        {
            this.bloodDonationDbContext = bloodDonationDbContext;
        }

        public async Task Add(TEntity entity)
        {
           await bloodDonationDbContext.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
             bloodDonationDbContext.Remove(entity);
        }
        public void Update(TEntity entity)
        {
           bloodDonationDbContext.Update(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
           return await bloodDonationDbContext.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await bloodDonationDbContext.Set<TEntity>().FindAsync(id);
        }

    }
}
