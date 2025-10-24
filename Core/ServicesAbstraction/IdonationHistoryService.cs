using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace ServicesAbstraction
{
    public interface IdonationHistoryService
    {
        public Task<IEnumerable<DonationHistoryResponseDto>> GetAllDonationHistory();
        public Task<IEnumerable<DonationHistoryResponseDto>> GetAllDonationHistoryByPatientId(int PatientId);
        public Task<IEnumerable<DonationHistoryResponseDto>> GetAllDonationHistoryByDonorId(int DonorId);

    }
}
