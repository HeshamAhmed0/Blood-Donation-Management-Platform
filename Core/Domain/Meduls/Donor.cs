using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls.Enums;

namespace Domain.Meduls
{
    public class Donor :BaseEntity<int>
    {
        [Required(ErrorMessage="Name Is Required")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "PhoneNumber Is Required")]
        [Phone(ErrorMessage="PhoneNumber Is Not Correct")]
        [StringLength(13,ErrorMessage =("Phone Number Must Increase Above 13"))]
        public string PhoneNumber { get; set; }= null!;
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage =("Email Is UnAvailable"))]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Blood Type Is Required")]
        public BloodTypes BloodType { get; set; } 

        [Required(ErrorMessage = "WorkDate Is Required")]
        public TimeOnly UnAvailableFrom { get; set; }
        [Required(ErrorMessage = "WorkDate Is Required")]
        public TimeOnly UnAvailableTo { get; set; }
        [Required(ErrorMessage = "LastDonationDate Is Required")]
        public DateTime LastDonationDate { get; set; }
        [Required(ErrorMessage = "Location Is Required")]
        public string Location { get; set; }=null!;
        public DateTime CreateAt { get; set; }=DateTime.Now;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<DonationHistory> DonationHistories { get; set; } = new List<DonationHistory>();
    }
}
