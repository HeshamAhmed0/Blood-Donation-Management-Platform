using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls.Enums;

namespace Shared
{
    public class DonationResponseDto
    {
        public int Id { get; set; }
        public string PatientName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public BloodTypesRequestDto NeedBloodType { get; set; }
        public bool IsUrgent { get; set; } = false;
        public string HospitalName { get; set; } = null!;
        public string HospitalLocation { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public StatusOfRequestDto Status { get; set; } 
    }
}
