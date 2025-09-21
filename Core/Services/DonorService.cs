using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracs;
using Domain.Exceptions.DonorExceptions;
using Domain.Meduls;
using Domain.Meduls.Enums;
using Persistence.DbContexts;
using Persistence.Reposatories;
using ServicesAbstraction;
using Shared;

namespace Services
{
    public class DonorService : IDonorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IDonorReposatory donorReposatory;

        public DonorService(IUnitOfWork unitOfWork,IDonorReposatory donorReposatory)
        {
            this.unitOfWork = unitOfWork;
            this.donorReposatory = donorReposatory;
        }
        public async Task<DonorResponseDto> AddDonor(DonorRequestDto donorRequestDto)
        {
            if (donorRequestDto is null) throw new DonorValidationException();
            var donor =await GetDonorsByIdOrNameOrEmailOrPhoneNumber(donorRequestDto.PhoneNumber);
            if (donor is not null) throw new DonorConflictException(donorRequestDto.Email);
            BloodTypes BloodTypeOfNewUser = (BloodTypes)donorRequestDto.BloodType;
            var NewDonor = new Donor()
            {
                Email = donorRequestDto.Email,
                BloodType = BloodTypeOfNewUser,
                LastDonationDate = donorRequestDto.LastDonationDate,
                CreateAt = DateTime.Now,
                Location = donorRequestDto.Location,
                Name = donorRequestDto.Name,
                PhoneNumber = donorRequestDto.PhoneNumber,
                UnAvailableFrom = donorRequestDto.UnAvailableFrom,
                UnAvailableTo = donorRequestDto.UnAvailableTo,
            };
            await unitOfWork.GenericReposatory<Donor, int>().Add(NewDonor);
            var result =await unitOfWork.SaveChangesAsync();
            if (result < 0)
            {
                throw new DonorDatabaseException();
            }
            var CheckForId =await donorReposatory.GetDonorsByIdOrNameOrEmailOrPhoneNumber(NewDonor.PhoneNumber);
            int id =CheckForId.Id;
                var DonorResponse = new DonorResponseDto()
                {
                    Id = id,
                    Email = donorRequestDto.Email,
                    BloodType = donorRequestDto.BloodType,
                    LastDonationDate = donorRequestDto.LastDonationDate,
                    CreateAt = DateTime.Now,
                    Location = donorRequestDto.Location,
                    Name = donorRequestDto.Name,
                    PhoneNumber = donorRequestDto.PhoneNumber,
                    UnAvailableFrom = donorRequestDto.UnAvailableFrom,
                    UnAvailableTo = donorRequestDto.UnAvailableTo,
                };
            return DonorResponse;
        }
        public async Task<DonorResponseDto> UpdateDonor(DonorUpdateDto donorUpdateDto)
        {
            if (donorUpdateDto == null) throw new DonorValidationException();
            var donorResponseDto =await GetDonorsByIdOrNameOrEmailOrPhoneNumber(donorUpdateDto.PhoneNumber);
            if (donorResponseDto == null) throw new DonorNotFoundException(donorUpdateDto.PhoneNumber);
            BloodTypes BloodTypeOfUpdateUser = (BloodTypes)donorUpdateDto.BloodType;
            var Donor =new Donor()
            {
                Id=donorResponseDto.Id,
                Email = donorUpdateDto.Email,
                BloodType = BloodTypeOfUpdateUser,
                LastDonationDate = donorUpdateDto.LastDonationDate,
                CreateAt = DateTime.Now,
                Location = donorUpdateDto.Location,
                Name = donorUpdateDto.Name,
                PhoneNumber = donorUpdateDto.PhoneNumber,
                UnAvailableFrom = donorUpdateDto.UnAvailableFrom,
                UnAvailableTo = donorUpdateDto.UnAvailableTo,
            };

             unitOfWork.GenericReposatory<Donor, int>().Update(Donor);
            var result = await unitOfWork.SaveChangesAsync();
            if(result < 0)
            {
                throw new DonorDatabaseException();
            }
            BloodTypesRequestDto BloodTypeOfResponse = (BloodTypesRequestDto)donorUpdateDto.BloodType;

            DonorResponseDto donorResponseDto1 = new DonorResponseDto()
            {
                Id = Donor.Id,
                Email = Donor.Email,
                BloodType = BloodTypeOfResponse,
                LastDonationDate = Donor.LastDonationDate,
                CreateAt = DateTime.Now,
                Location = Donor.Location,
                Name = Donor.Name,
                PhoneNumber = Donor.PhoneNumber,
                UnAvailableFrom = Donor.UnAvailableFrom,
                UnAvailableTo = Donor.UnAvailableTo,
            };
            return donorResponseDto1;
        }
        public async Task<string> DeleteDonor(int Id)
        {
            if (Id == null) throw new DonorValidationException();
            var donor = await donorReposatory.GetDonorsByIdOrNameOrEmailOrPhoneNumber(Id);
            if (donor == null) throw new DonorNotFoundException(Id);
            unitOfWork.GenericReposatory<Donor,int>().Delete(donor);
            var result =await unitOfWork.SaveChangesAsync();
            if(result <= 0)
            {
                throw new DonorDatabaseDelete();
            }
            return result.ToString();
        }
        public async Task<IEnumerable<DonorResponseDto>> GetAllDonors()
        {
            var result = await unitOfWork.GenericReposatory<Donor, int>().GetAllAsync();
            if (result == null) throw new DonorNotFoundException();
            var donorResponseDtos = new List<DonorResponseDto>();
            foreach (var donor in result)
            {
                BloodTypesRequestDto BloodTypeForOnes = (BloodTypesRequestDto)donor.BloodType;
                var dto = new DonorResponseDto
                {
                    Id = donor.Id,
                    Name = donor.Name,
                    Email = donor.Email,
                    PhoneNumber = donor.PhoneNumber,
                    BloodType = BloodTypeForOnes,
                    Location = donor.Location,
                    LastDonationDate = donor.LastDonationDate,
                    UnAvailableFrom = donor.UnAvailableFrom,
                    UnAvailableTo = donor.UnAvailableTo,
                    CreateAt = donor.CreateAt
                };
                donorResponseDtos.Add(dto);
            }
            return donorResponseDtos;
        }
        public async Task<DonorResponseDto> GetDonorsByIdOrNameOrEmailOrPhoneNumber(int Id)
        {
            if (Id == null) throw new Exception("Id Not Allow To be Null");
            var donorRequestDto = await donorReposatory.GetDonorsByIdOrNameOrEmailOrPhoneNumber(Id);
            if (donorRequestDto == null) return null;
            BloodTypesRequestDto BloodOFUser = (BloodTypesRequestDto)donorRequestDto.BloodType;
            var DonorResponse = new DonorResponseDto()
            {
                Id = donorRequestDto.Id,
                Email = donorRequestDto.Email,
                BloodType = BloodOFUser,
                LastDonationDate = donorRequestDto.LastDonationDate,
                CreateAt = DateTime.Now,
                Location = donorRequestDto.Location,
                Name = donorRequestDto.Name,
                PhoneNumber = donorRequestDto.PhoneNumber,
                UnAvailableFrom = donorRequestDto.UnAvailableFrom,
                UnAvailableTo = donorRequestDto.UnAvailableTo,
            };
            return DonorResponse;
        }
        public async Task<DonorResponseDto> GetDonorsByIdOrNameOrEmailOrPhoneNumber(string NameOrEmailOrPhoneNumber)
        {
            if (NameOrEmailOrPhoneNumber == null) throw new Exception("NameOrEmailOrPhoneNumber Not Allow To be Null");
            var donorRequestDto = await donorReposatory.GetDonorsByIdOrNameOrEmailOrPhoneNumber(NameOrEmailOrPhoneNumber);
            if (donorRequestDto == null) return null;
            BloodTypesRequestDto BloodOFUser = (BloodTypesRequestDto)donorRequestDto.BloodType;
            var DonorResponse = new DonorResponseDto()
            {
                Id= donorRequestDto.Id,
                Email = donorRequestDto.Email,
                BloodType = BloodOFUser,
                LastDonationDate = donorRequestDto.LastDonationDate,
                CreateAt = DateTime.Now,
                Location = donorRequestDto.Location,
                Name = donorRequestDto.Name,
                PhoneNumber = donorRequestDto.PhoneNumber,
                UnAvailableFrom = donorRequestDto.UnAvailableFrom,
                UnAvailableTo = donorRequestDto.UnAvailableTo,
            };
            return DonorResponse;
        }

    }
}
