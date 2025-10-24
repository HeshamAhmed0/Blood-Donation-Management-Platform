using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracs;
using Domain.Exceptions.DonationHistory;
using Domain.Meduls;
using ServicesAbstraction;
using Shared;

namespace Services
{
    public class DonationHistoryService(IDonationHistoryReposatory donationHistoryReposatory) : IdonationHistoryService
    {
        private readonly IDonationHistoryReposatory donationHistoryReposatory = donationHistoryReposatory;

        public async Task<IEnumerable<DonationHistoryResponseDto>> GetAllDonationHistory()
        {
            var result= await donationHistoryReposatory.GetAllAsync();
            if (result == null) throw new DonationHistoryNotFoundException();
            var response = new List <DonationHistoryResponseDto>();
            foreach (var item in result)
            {
                var newItem = new DonationHistoryResponseDto()
                {
                    DonationDate =item.DonationDate,
                    DonerId=item.DonerId,
                    Notes = item.Notes,
                    PatieentId=item.PatieentId,
                };
                response.Add(newItem);
            }
            return response;
        }

        public async Task<IEnumerable<DonationHistoryResponseDto>> GetAllDonationHistoryByDonorId(int DonorId)
        {
            var result = await donationHistoryReposatory.GetAllDonationHistoryByDonorId(DonorId);
            if (result == null) throw new DonationHistoryNotFoundException(DonorId);
            var response = new List<DonationHistoryResponseDto>();
            foreach (var item in result)
            {
                var newItem = new DonationHistoryResponseDto()
                {
                    DonationDate = item.DonationDate,
                    DonerId = item.DonerId,
                    Notes = item.Notes,
                    PatieentId = item.PatieentId,
                };
                response.Add(newItem);
            }
            return response;
        }

        public async Task<IEnumerable<DonationHistoryResponseDto>> GetAllDonationHistoryByPatientId(int PatientId)
        {
            var result = await donationHistoryReposatory.GetAllDonationHistoryByPatientId(PatientId);
            if (result == null) throw new DonationHistoryNotFoundException(PatientId);
            var response = new List<DonationHistoryResponseDto>();
            foreach (var item in result)
            {
                var newItem = new DonationHistoryResponseDto()
                {
                    DonationDate = item.DonationDate,
                    DonerId = item.DonerId,
                    Notes = item.Notes,
                    PatieentId = item.PatieentId,
                };
                response.Add(newItem);
            }
            return response;
        }
    }
}
