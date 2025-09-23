using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls.Enums;

namespace Shared
{
    public class DonationRequestDto
    {
        [Required(ErrorMessage = "Name Is Required")]
        [StringLength(100, ErrorMessage = "Name Must Not Increase Above 100 Character")]
        public string PatientName { get; set; } = null!;
     
        
        [Required(ErrorMessage = "PhoneNumber Is Required")]
        [Phone(ErrorMessage = "PhoneNumber Is Not Correct")]
        [StringLength(13, ErrorMessage = ("Phone Number Must Increase Above 13"))]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = ("Email Is UnAvailable"))]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "Blood Type Is Required")]
        public BloodTypesRequestDto NeedBloodType { get; set; }
        [Required(ErrorMessage = "IsUrgent Is Required")]
        public bool IsUrgent { get; set; } = false;
        [Required(ErrorMessage = "Hospital Name Is Required")]
        public string HospitalName { get; set; } = null!;
        [Required(ErrorMessage = "Hospital Location Is Required")]
        public string HospitalLocation { get; set; } = null!;
        [Required(ErrorMessage = "Latitude Is Required")]
        public double Latitude { get; set; }
        [Required(ErrorMessage = "Longitude Is Required")]
        public double Longitude { get; set; }
        [Required(ErrorMessage = "Request Date Is Required")]
        public DateTime RequestDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Status Is Required")]
        public StatusOfRequestDto Status { get; set; }
    }
}
