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
    public class DonationHistoryReposatory(BloodDonationDbContext bloodDonationDbContext) : GenericReposatory<DonationHistory, int>(bloodDonationDbContext), IDonationHistoryReposatory
    {
        private readonly BloodDonationDbContext bloodDonationDbContext = bloodDonationDbContext;

        public async Task<IEnumerable<DonationHistory>> GetAllDonationHistoryByDonorId(int DonorId)
        {
            var result = await GetAllAsync();
            if (result == null) return null;
            var resultAfterFilteration =  result.Where(D => D.DonerId == DonorId);
            return resultAfterFilteration;
        }

        public async Task<IEnumerable<DonationHistory>> GetAllDonationHistoryByPatientId(int PatientId)
        {
            var result = await GetAllAsync();
            if (result == null) return null;
            var resultAfterFilteration = result.Where(D => D.PatieentId == PatientId);
            return resultAfterFilteration;
        }
    }
}
