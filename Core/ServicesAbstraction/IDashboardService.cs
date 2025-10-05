using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls.Enums;
using Shared;

namespace ServicesAbstraction
{
    public interface IDashboardService
    {
        public Task<int> CountOfDonationRequest();
        public Task<int> CountOfDonors();
        public Task<IEnumerable<DonationResponseDto>> GetAllDonationRequest();
        public Task<IEnumerable<DonationResponseDto>> GetDonationRequestsByBloodType(BloodTypesRequestDto bloodTypesRequestDto);
        public Task<DonationResponseDto> UpdateDonationRequestStatus(int DonationRequestId, StatusOfRequestDto statusOfRequestDto);
        public Task<IEnumerable<DonorResponseDto>> GetAllDonors();
        public Task<IEnumerable<DonorResponseDto> > GetDonorsByBloodType(BloodTypesRequestDto bloodTypesRequestDto);
        public Task<DonorResponseDto> AddDonor(DonorRequestDto donorRequestDto);
        public Task<DonorResponseDto> UpdateDonor(DonorUpdateDto donorUpdateDto);
        public Task<DonationHistoryResponseDto> AddDonationHistory(DonationHistoryRequestDto donationHistoryRequestDto);
        public Task<IEnumerable<DonationHistoryResponseDto>> GetAllDonationHistory();
        public Task<IEnumerable<DonationHistoryResponseDto>> GetAllDonationHistoryByBloodType(BloodTypesRequestDto bloodTypesRequestDto);
        public Task<IEnumerable<DonationHistoryResponseDto>> GetDonationHistoryForDonor(string PhoneNumber);
    }
}
