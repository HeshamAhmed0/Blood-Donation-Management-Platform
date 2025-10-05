using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracs;
using Domain.Exceptions.DonationRequestExceptions;
using Domain.Exceptions.DonorExceptions;
using Domain.Meduls;
using Domain.Meduls.Enums;
using ServicesAbstraction;
using Shared;

namespace Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDonorService donorService;
        private readonly IDonationRequestService donationRequestService;
        private readonly IUnitOfWork unitOfWork;

        public DashboardService(IDonorService donorService,IDonationRequestService donationRequestService,IUnitOfWork unitOfWork)
        {
            this.donorService = donorService;
            this.donationRequestService = donationRequestService;
            this.unitOfWork = unitOfWork;
        }

        public async Task<DonationHistoryResponseDto> AddDonationHistory(DonationHistoryRequestDto donationHistoryRequestDto)
        {
            var donor =await donorService.GetDonorsByIdOrNameOrEmailOrPhoneNumber(donationHistoryRequestDto.DonerId);
            if (donor == null) throw new DonorNotFoundException(donationHistoryRequestDto.DonerId);
            var donationRequest =await donationRequestService.GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(donationHistoryRequestDto.PatieentId);
            if (donationRequest == null) throw new DonationRequestNotFoundException(donationHistoryRequestDto.DonerId);
            var donationHistory = new DonationHistory()
            {
                DonerId=donationHistoryRequestDto.DonerId,
                DonationDate=DateTime.Now,
                PatieentId= donationHistoryRequestDto.PatieentId,
            };
             await unitOfWork.GenericReposatory<DonationHistory, int>().Add(donationHistory);
            var result =await unitOfWork.SaveChangesAsync();
            if (result < 0) throw new Exception("Exception Occure While Saving Data In Database");
            var donationHistoryResponseDto = new DonationHistoryResponseDto()
            {
                DonationDate= donationHistory.DonationDate,
                DonerId= donationHistory.DonerId,
                PatieentId= donationHistory.PatieentId
            };
            return donationHistoryResponseDto;
        }

        public async Task<DonorResponseDto> AddDonor(DonorRequestDto donorRequestDto)
        {
            var result = await donorService.AddDonor(donorRequestDto);
            return result;
        }

        public async Task<int> CountOfDonationRequest()
        {
            var donationrequest = await donationRequestService.GetAllDonationRequest();
            if (donationrequest == null) throw new Exception("There Are Not Any DonationRequest");
            int countOfDonationRequests =donationrequest.Count(); 
            return countOfDonationRequests;
        }

        public async Task<int> CountOfDonors()
        {
            var donors = await donorService.GetAllDonors();
            if (donors == null) throw new Exception("There Are Not Donors");
            int CountOfDonors =donors.Count();
            return CountOfDonors;
        }

        public Task<IEnumerable<DonationHistoryResponseDto>> GetAllDonationHistory()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DonationHistoryResponseDto>> GetAllDonationHistoryByBloodType(BloodTypesRequestDto bloodTypesRequestDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DonationResponseDto>> GetAllDonationRequest()
        {
            var result = await donationRequestService.GetAllDonationRequest();
            return result;
        }

        public async Task<IEnumerable<DonorResponseDto>> GetAllDonors()
        {
            var donors = await donorService.GetAllDonors();
            return donors;
        }

        public Task<IEnumerable<DonationHistoryResponseDto>> GetDonationHistoryForDonor(string PhoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DonationResponseDto>> GetDonationRequestsByBloodType(BloodTypesRequestDto bloodTypesRequestDto)
        {
            var donationrequest = await donationRequestService.GetAllDonationRequest();
            if (donationrequest == null) throw new Exception("There Are Not Any DonationRequest");
            var donationRequestWithSpecificBloodType = donationrequest.Where(B => B.NeedBloodType == bloodTypesRequestDto);
            if (donationRequestWithSpecificBloodType == null) throw new Exception($"There Are Not DonationRequest With BloodType : {bloodTypesRequestDto}");
            return donationRequestWithSpecificBloodType;
        }

        public async Task<IEnumerable<DonorResponseDto>> GetDonorsByBloodType(BloodTypesRequestDto bloodTypesRequestDto)
        {
           var donors =await donorService.GetAllDonors();
            if (donors == null) throw new Exception("There Are Not Donors");
            var DonorsWithSpecificBloodType = donors.Where(B => B.BloodType == bloodTypesRequestDto);
            if (DonorsWithSpecificBloodType == null) throw new Exception($"There Are Not Donors With Blood Type : {bloodTypesRequestDto}");
            return DonorsWithSpecificBloodType;
        }

        public async Task<DonationResponseDto> UpdateDonationRequestStatus(int DonationRequestId, StatusOfRequestDto NewstatusOfRequestDto)
        {
            var donationResponsedto =await donationRequestService.GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(DonationRequestId);
            donationResponsedto.Status = NewstatusOfRequestDto;
            var donationUpdateDto = new DonationUpdateDto()
            {
                Id = donationResponsedto.Id,
                Email = donationResponsedto.Email,
                RequestDate = donationResponsedto.RequestDate,
                HospitalLocation=donationResponsedto.HospitalLocation,
                Status = donationResponsedto.Status,
                HospitalName=donationResponsedto.HospitalName,
                IsUrgent=donationResponsedto.IsUrgent,
                Latitude=donationResponsedto.Latitude,
                Longitude=donationResponsedto.Longitude,
                NeedBloodType=donationResponsedto.NeedBloodType,
                PatientName=donationResponsedto.PatientName,
                PhoneNumber=donationResponsedto.PhoneNumber,
            };
           var result =await donationRequestService.UpdateDonationRequest(donationUpdateDto);
            if (result == null) throw new DonationRequestDatabaseDelete();
            return result;
        }

        public async Task<DonorResponseDto> UpdateDonor(DonorUpdateDto donorUpdateDto)
        {
            var result = await donorService.UpdateDonor(donorUpdateDto);
            return result;
        }
    }
}
