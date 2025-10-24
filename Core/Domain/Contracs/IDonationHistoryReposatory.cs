using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls;

namespace Domain.Contracs
{
    public interface IDonationHistoryReposatory :IGenericReposatory<DonationHistory,int>
    {
        public Task<IEnumerable<DonationHistory>> GetAllDonationHistoryByPatientId(int PatientId);
        public Task<IEnumerable<DonationHistory>> GetAllDonationHistoryByDonorId(int DonorId);
    }
}
