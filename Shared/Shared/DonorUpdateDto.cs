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
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public BloodTypesRequestDto BloodType { get; set; }
        public TimeOnly UnAvailableFrom { get; set; }
        public TimeOnly UnAvailableTo { get; set; }
        public DateTime LastDonationDate { get; set; }
        public string Location { get; set; } = null!;
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
