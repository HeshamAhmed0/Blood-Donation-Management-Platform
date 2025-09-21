using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracs;
using Persistence.DbContexts;
using ServicesAbstraction;

namespace Services
{
    public class ServiceManager(IUnitOfWork unitOfWork,IDonorReposatory donorReposatory) : IServiceManager
    {

        public IDonorService donorService { get; } =new DonorService(unitOfWork,donorReposatory);
    }
}
