using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace ServicesAbstraction
{
    public interface IDonationRequestService 
    {
        public Task<DonationResponseDto> AddDonationRequest(DonationRequestDto donationRequestDto);
        public Task<DonationResponseDto> UpdateDonationRequest(DonationUpdateDto donationUpdateDto);
        public Task<string> DeleteDonationRequest(int Id);
        public Task<IEnumerable<DonationResponseDto>> GetAllDonationRequest();
        public Task<DonationResponseDto> GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(int Id);
        public Task<DonationResponseDto> GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(string NameOrEmailOrPhoneNumber);
    }
}
