using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Meduls.Enums;

namespace Domain.Meduls
{
    public class DonationRequest :BaseEntity<int>
    {
        [Required(ErrorMessage ="Name Is Required")]
        [StringLength(100,ErrorMessage ="Name Must Not Increase Above 100 Character")]
        public string PatientName { get; set; } = null!;
        [Required(ErrorMessage ="Blood Type Is Required")]
        public BloodTypes NeedBloodType {  get; set; }
        [Required(ErrorMessage ="IsUrgent Is Required")]
        public bool IsUrgent {  get; set; }=false;
        [Required(ErrorMessage ="Hospital Name Is Required")]
        public string HospitalName { get; set; } =null!;
        [Required(ErrorMessage = "Hospital Location Is Required")]
        public string HospitalLocation { get;set; } =null!;
        [Required(ErrorMessage = "Request Date Is Required")]
        public DateTime RequestDate { get; set; }=DateTime.Now;

        [Required(ErrorMessage = "Status Is Required")]
        public StatusOfRequest Status {  get; set; } =StatusOfRequest.Pending;

    }
}
