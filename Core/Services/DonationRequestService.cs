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
using Persistence.Reposatories;
using ServicesAbstraction;
using Shared;

namespace Services
{
    public class DonationRequestService : IDonationRequestService
    {
        private readonly IDonationRequestReposatory donationRequestReposatory;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDonorService donorService;
        private readonly INotificationService notificationService;

        public DonationRequestService(IDonationRequestReposatory donationRequestReposatory,IUnitOfWork unitOfWork ,IDonorService donorService,INotificationService notificationService)
        {
            this.donationRequestReposatory = donationRequestReposatory;
            this.unitOfWork = unitOfWork;
            this.donorService = donorService;
            this.notificationService = notificationService;
        }

        public async Task<DonationResponseDto> AddDonationRequest(DonationRequestDto donationRequestDto)
        {
           if(donationRequestDto == null || donationRequestDto.PhoneNumber==null ||donationRequestDto.Email==null) throw new DonationRequestValidationException();
           StatusOfRequest status =(StatusOfRequest)donationRequestDto.Status;
            BloodTypes bloodTypes =(BloodTypes)donationRequestDto.NeedBloodType;
            DonationRequest donationRequest = new DonationRequest()
            {
                RequestDate = DateTime.Now,
                Status= status,
                Email=donationRequestDto.Email,
                HospitalLocation=donationRequestDto.HospitalLocation,
                HospitalName=donationRequestDto.HospitalName,
                IsUrgent=donationRequestDto.IsUrgent,
                NeedBloodType=bloodTypes,
                PatientName=donationRequestDto.PatientName,
                PhoneNumber=donationRequestDto.PhoneNumber,
                Longitude=donationRequestDto.Longitude,
                Latitude=donationRequestDto.Latitude,
            };
            await donationRequestReposatory.Add(donationRequest);
            var result =await unitOfWork.SaveChangesAsync();
            if (result < 0) throw new DonationRequestDatabaseException();


            #region SendEmailMessage
            var Donors = await donorService.GetAllDonors();
            var ValidDonors = Donors.Where(B => B.BloodType == donationRequestDto.NeedBloodType && B.LastDonationDate.AddMonths(3) <= DateTime.Now);
            foreach (var donor in ValidDonors)
            {
               await notificationService.SendEmailAsync(donor.Email, donationRequestDto.PatientName, donationRequestDto.HospitalLocation, donationRequestDto.Latitude, donationRequestDto.Longitude);
               //await notificationService.SendSmsAsync(donor.PhoneNumber,donor.Name,donor.Latitude, donor.Longitude);
            }
          

            #endregion


            StatusOfRequestDto statusOfResponse = (StatusOfRequestDto)donationRequestDto.Status;
            BloodTypesRequestDto bloodTypesOfResponse = (BloodTypesRequestDto)donationRequestDto.NeedBloodType;
            var CheckForId = await donationRequestReposatory.GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(donationRequestDto.PhoneNumber);
            int id = CheckForId.Id;
            DonationResponseDto donationResponseDto = new DonationResponseDto()
            {
                Id= id,
                RequestDate = DateTime.Now,
                Status = statusOfResponse,
                Email = donationRequestDto.Email,
                HospitalLocation = donationRequestDto.HospitalLocation,
                HospitalName = donationRequestDto.HospitalName,
                IsUrgent = donationRequestDto.IsUrgent,
                NeedBloodType = bloodTypesOfResponse,
                PatientName = donationRequestDto.PatientName,
                PhoneNumber = donationRequestDto.PhoneNumber,
                Latitude = donationRequestDto.Latitude,
                Longitude = donationRequestDto.Longitude,
            };
            return donationResponseDto;

        }
        public async Task<DonationResponseDto> UpdateDonationRequest(DonationUpdateDto donationUpdateDto)
        {
            if (donationUpdateDto == null) throw new DonationRequestValidationException();
            var DonationRequest = await CheckForDonationRequest(donationUpdateDto.Id);
            if (DonationRequest == null) throw new DonationRequestNotFoundException(donationUpdateDto.PhoneNumber);
            DonationRequest.PhoneNumber = donationUpdateDto.PhoneNumber;
            DonationRequest.Email= donationUpdateDto.Email;
            DonationRequest.HospitalLocation=donationUpdateDto.HospitalLocation;
            DonationRequest.PatientName=donationUpdateDto.PatientName;
            DonationRequest.RequestDate = donationUpdateDto.RequestDate;
            DonationRequest.HospitalName=donationUpdateDto.HospitalName;
            DonationRequest.IsUrgent = donationUpdateDto.IsUrgent;
            DonationRequest.Longitude = donationUpdateDto.Longitude;
            DonationRequest.Latitude = donationUpdateDto.Latitude;
            BloodTypes bloodTypes = (BloodTypes)donationUpdateDto.NeedBloodType;
            DonationRequest.NeedBloodType = bloodTypes;
            StatusOfRequest status = (StatusOfRequest)donationUpdateDto.Status;
            DonationRequest.Status = status;
            var result = await unitOfWork.SaveChangesAsync();
            if (result < 0)
            {
                throw new DonationRequestDatabaseException();
            }
            BloodTypesRequestDto BloodTypeOfResponse = (BloodTypesRequestDto)donationUpdateDto.NeedBloodType;
            StatusOfRequestDto statusOfResponse = (StatusOfRequestDto)donationUpdateDto.Status;
            DonationResponseDto donationResponseDto = new DonationResponseDto()
            {
                Id= donationUpdateDto.Id,
                RequestDate = DateTime.Now,
                Status = statusOfResponse,
                Email = donationUpdateDto.Email,
                HospitalLocation = donationUpdateDto.HospitalLocation,
                HospitalName = donationUpdateDto.HospitalName,
                IsUrgent = donationUpdateDto.IsUrgent,
                NeedBloodType = BloodTypeOfResponse,
                PatientName = donationUpdateDto.PatientName,
                PhoneNumber = donationUpdateDto.PhoneNumber,
                Latitude = donationUpdateDto.Latitude,
                Longitude = donationUpdateDto.Longitude,
            };
            return donationResponseDto;
        }

        public async Task<string> DeleteDonationRequest(int Id)
        {
            if (Id == null) throw new DonationRequestValidationException();
            var donor = await donationRequestReposatory.GetByIdAsync(Id);
            if (donor == null) throw new DonationRequestNotFoundException(Id);
             donationRequestReposatory.Delete(donor);
            var result = await unitOfWork.SaveChangesAsync();
            if (result <= 0)
            {
                throw new DonationRequestDatabaseDelete();
            }
            return result.ToString();
        }

        public async Task<IEnumerable<DonationResponseDto>> GetAllDonationRequest()
        {
            var result = await donationRequestReposatory.GetAllAsync();
            if (result == null) throw new DonationRequestNotFoundException();
            var donationResponseDtos = new List<DonationResponseDto>();
            foreach (var DonationRequest in result)
            {
                BloodTypesRequestDto BloodTypeOfResponse = (BloodTypesRequestDto)DonationRequest.NeedBloodType;
                StatusOfRequestDto statusOfResponse = (StatusOfRequestDto)DonationRequest.Status;
                DonationResponseDto donationResponseDto = new DonationResponseDto()
                {
                    Id = DonationRequest.Id,
                    RequestDate = DateTime.Now,
                    Status = statusOfResponse,
                    Email = DonationRequest.Email,
                    HospitalLocation = DonationRequest.HospitalLocation,
                    HospitalName = DonationRequest.HospitalName,
                    IsUrgent = DonationRequest.IsUrgent,
                    NeedBloodType = BloodTypeOfResponse,
                    PatientName = DonationRequest.PatientName,
                    PhoneNumber = DonationRequest.PhoneNumber,
                    Longitude = DonationRequest.Longitude,
                    Latitude = DonationRequest.Latitude,
                };
                donationResponseDtos.Add(donationResponseDto);

            }
            return donationResponseDtos;
        }

        public async Task<DonationResponseDto> GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(int Id)
        {
            if (Id == null) throw new DonationRequestValidationException();
            var donationRequestDto = await donationRequestReposatory.GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(Id);
            if (donationRequestDto == null) throw new DonationRequestNotFoundException(Id);
            BloodTypesRequestDto BloodTypeOfResponse = (BloodTypesRequestDto)donationRequestDto.NeedBloodType;
            StatusOfRequestDto statusOfResponse = (StatusOfRequestDto)donationRequestDto.Status;
            DonationResponseDto donationResponseDto = new DonationResponseDto()
            {
                Id= Id,
                RequestDate = DateTime.Now,
                Status = statusOfResponse,
                Email = donationRequestDto.Email,
                HospitalLocation = donationRequestDto.HospitalLocation,
                HospitalName = donationRequestDto.HospitalName,
                IsUrgent = donationRequestDto.IsUrgent,
                NeedBloodType = BloodTypeOfResponse,
                PatientName = donationRequestDto.PatientName,
                PhoneNumber = donationRequestDto.PhoneNumber,
                Latitude = donationRequestDto.Latitude,
                Longitude = donationRequestDto.Longitude,
            };
            return donationResponseDto;
        }

        public async Task<DonationResponseDto> GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(string NameOrEmailOrPhoneNumber)
        {
            if (NameOrEmailOrPhoneNumber == null) throw new DonationRequestValidationException();
            var donationRequestDto = await donationRequestReposatory.GetDonationRequestByIdOrNameOrEmailOrPhoneNumber(NameOrEmailOrPhoneNumber);
            if (donationRequestDto == null) throw new DonationRequestNotFoundException();
            BloodTypesRequestDto BloodTypeOfResponse = (BloodTypesRequestDto)donationRequestDto.NeedBloodType;
            StatusOfRequestDto statusOfResponse = (StatusOfRequestDto)donationRequestDto.Status;
            DonationResponseDto donationResponseDto = new DonationResponseDto()
            {
                Id= donationRequestDto.Id,
                RequestDate = DateTime.Now,
                Status = statusOfResponse,
                Email = donationRequestDto.Email,
                HospitalLocation = donationRequestDto.HospitalLocation,
                HospitalName = donationRequestDto.HospitalName,
                IsUrgent = donationRequestDto.IsUrgent,
                NeedBloodType = BloodTypeOfResponse,
                PatientName = donationRequestDto.PatientName,
                PhoneNumber = donationRequestDto.PhoneNumber,
                Longitude = donationRequestDto.Longitude,
                Latitude = donationRequestDto.Latitude,
            };
            return donationResponseDto;
        }

        private async Task<DonationRequest> CheckForDonationRequest(int id)
        {
            var result = await donationRequestReposatory.GetByIdAsync(id);
            return result;
        }

    }
}
