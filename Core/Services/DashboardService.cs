using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracs;
using Domain.Exceptions.DonationHistory;
using Domain.Exceptions.DonationRequestExceptions;
using Domain.Meduls;
using Domain.Meduls.Enums;
using ServicesAbstraction;
using Shared;

namespace Services
{
    public class DashboardService(IUnitOfWork unitOfWork , 
                                  IDonorService donorService , 
                                  IDonationRequestService donationRequestService,
                                  IdonationHistoryService donationHistoryService) : IDashboardService
    {
        private readonly IUnitOfWork unitOfWork = unitOfWork;
        private readonly IdonationHistoryService donationHistoryService = donationHistoryService;

        public async Task<DonationHistoryResponseDto> AddDonationHistory(DonationHistoryRequestDto donationHistoryRequestDto)
        {
            if (donationHistoryRequestDto == null) throw new DonationRequestValidationException();
            DonationHistory donationHistory = new DonationHistory()
            {
                PatieentId=donationHistoryRequestDto.PatieentId,
                DonationDate=donationHistoryRequestDto.DonationDate,
                DonerId=donationHistoryRequestDto.DonerId,
                Notes=donationHistoryRequestDto.Notes,
            };
            await unitOfWork.GenericReposatory<DonationHistory, int>().Add(donationHistory);
            var result = await unitOfWork.SaveChangesAsync();
            if (result <= 0) throw new DonationHistoryRequestDatabaseException();
            var response = new DonationHistoryResponseDto()
            {
                DonationDate = donationHistory.DonationDate,
                DonerId = donationHistory.DonerId,
                Notes = donationHistory.Notes,
                PatieentId = donationHistory.PatieentId
            };
            return response;
        }

        public async Task<DonorResponseDto> AddDonor(DonorRequestDto donorRequestDto)
        {
           var result = await donorService.AddDonor(donorRequestDto);
            return result;
        }

        public async Task<int> CountOfDonationRequest()
        {
            var result = await donationRequestService.GetAllDonationRequest();
            var response = result.Count();
            return response;
        }

        public async Task<int> CountOfDonors()
        {
            var result = await donorService.GetAllDonors();
            var response = result.Count();
            return response;
        }

        public async Task<IEnumerable<DonationHistoryResponseDto>> GetAllDonationHistory()
        {
            var result = await donationHistoryService.GetAllDonationHistory();
            return result;
        }

        public async Task<IEnumerable<DonationHistoryResponseDto>> GetAllDonationHistoryByDonorId(int DonorId)
        {
           var result = await donationHistoryService.GetAllDonationHistoryByDonorId(DonorId);
            return result;
        }

        public async Task<IEnumerable<DonationHistoryResponseDto>> GetAllDonationHistoryByPatientId(int PatientId)
        {
           var result = await donationHistoryService.GetAllDonationHistoryByPatientId(PatientId);
            return result;
        }

        public async Task<IEnumerable<DonationResponseDto>> GetAllDonationRequest()
        {
            var result = await donationRequestService.GetAllDonationRequest();
            return result;
        }

        public async Task<IEnumerable<DonorResponseDto>> GetAllDonors()
        {
            var result = await donorService.GetAllDonors();
            return result;
        }

        public async Task<IEnumerable<DonationResponseDto>> GetDonationRequestsByBloodType(BloodTypesRequestDto bloodTypesRequestDto)
        {
            var AllDonationRequest = await donationRequestService.GetAllDonationRequest();
            var resultAfterFilteration = AllDonationRequest.Where(B => B.NeedBloodType == bloodTypesRequestDto);
            return resultAfterFilteration;
        }

        public async Task<IEnumerable<DonorResponseDto>> GetDonorsByBloodType(BloodTypesRequestDto bloodTypesRequestDto)
        {
            var AllDonors = await donorService.GetAllDonors();
            var resultAfterFilteration = AllDonors.Where(B => B.BloodType == bloodTypesRequestDto);
            return resultAfterFilteration;
        }

        public async Task<DonationResponseDto> UpdateDonationRequestStatus(int DonationRequestId, StatusOfRequestDto statusOfRequestDto)
        {
            var DonationRequest = await donationRequestService.GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(DonationRequestId);
            if (DonationRequest == null) throw new DonationRequestNotFoundException(DonationRequestId);
            var DonationUpdateDto = new DonationUpdateDto()
            {
                Id = DonationRequestId,
                RequestDate = DateTime.Now,
                Email=DonationRequest.Email,
                HospitalLocation=DonationRequest.HospitalLocation,
                Status = statusOfRequestDto,
                HospitalName=DonationRequest.HospitalName,
                IsUrgent=DonationRequest.IsUrgent,
                Latitude=DonationRequest.Latitude,
                Longitude=DonationRequest.Longitude,
                NeedBloodType=DonationRequest.NeedBloodType,
                PatientName=DonationRequest.PatientName,
                PhoneNumber=DonationRequest.PhoneNumber,
            };
            var result = await donationRequestService.UpdateDonationRequest(DonationUpdateDto);
            return result;
        }

        public async Task<DonorResponseDto> UpdateDonor(DonorUpdateDto donorUpdateDto)
        {
            var result = await donorService.UpdateDonor(donorUpdateDto);
            return result;
        }
    }
}
