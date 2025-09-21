using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Meduls.Enums;

namespace Services.MappingProfiles
{
    public class DonorProfile : Profile
    {
        protected DonorProfile()
        {
            CreateMap<BloodTypesRequestDto, BloodTypes>().ConvertUsing(src => (BloodTypes)src);
            CreateMap<BloodTypes, BloodTypesRequestDto>().ConvertUsing(src => (BloodTypesRequestDto)src);
        }
    }
}
