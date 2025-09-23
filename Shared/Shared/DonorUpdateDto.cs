using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls.Enums;

namespace Shared
{
    public class DonorUpdateDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "PhoneNumber Is Required")]
        [Phone(ErrorMessage = "PhoneNumber Is Not Correct")]
        [StringLength(13, ErrorMessage = ("Phone Number Must Increase Above 13"))]
        public string PhoneNumber { get; set; } = null!;
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = ("Email Is UnAvailable"))]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Blood Type Is Required")]
        public BloodTypesRequestDto BloodType { get; set; }

        [Required(ErrorMessage = "WorkDate Is Required")]
        public TimeOnly UnAvailableFrom { get; set; }
        [Required(ErrorMessage = "WorkDate Is Required")]
        public TimeOnly UnAvailableTo { get; set; }
        [Required(ErrorMessage = "LastDonationDate Is Required")]
        public DateTime LastDonationDate { get; set; }
        [Required(ErrorMessage = "Location Is Required")]
        public string Location { get; set; } = null!;
        [Required(ErrorMessage = "Latitude Is Required")]
        public double Latitude { get; set; }
        [Required(ErrorMessage = "Longitude Is Required")]
        public double Longitude { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
