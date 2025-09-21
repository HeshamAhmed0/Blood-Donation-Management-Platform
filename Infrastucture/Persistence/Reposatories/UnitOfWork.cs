using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracs;
using Domain.Meduls;
using Persistence.DbContexts;

namespace Persistence.Reposatories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BloodDonationDbContext bloodDonationDbContext;
        private readonly Dictionary<string,object> Reposatories;
        public UnitOfWork(BloodDonationDbContext bloodDonationDbContext)
        {
            this.bloodDonationDbContext = bloodDonationDbContext;
            Reposatories=new Dictionary<string,object>();
        }

        public IGenericReposatory<TEntity, Tkey> GenericReposatory<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
           var type = typeof(TEntity).Name;
            if(!Reposatories.ContainsKey(type))
            {
                var reposatory =new GenericReposatory<TEntity,Tkey>(bloodDonationDbContext);
                Reposatories.Add(type, reposatory);
            }
            return Reposatories[type] as IGenericReposatory<TEntity, Tkey>;
        }

        public async Task<int> SaveChangesAsync()
        {
           return await bloodDonationDbContext.SaveChangesAsync();
        }
    }
}
