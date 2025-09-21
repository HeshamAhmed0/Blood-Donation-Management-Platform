using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace ServicesAbstraction
{
    public interface IDonorService
    {
        public Task<DonorResponseDto> AddDonor(DonorRequestDto donorRequestDto);
        public Task<DonorResponseDto> UpdateDonor(DonorUpdateDto donorUpdateDto);
        public Task<string> DeleteDonor(int Id);
        public Task<IEnumerable<DonorResponseDto>> GetAllDonors();
        public Task<DonorResponseDto> GetDonorsByIdOrNameOrEmailOrPhoneNumber(int Id);
        public Task<DonorResponseDto> GetDonorsByIdOrNameOrEmailOrPhoneNumber(string NameOrEmailOrPhoneNumber);
    }
}
