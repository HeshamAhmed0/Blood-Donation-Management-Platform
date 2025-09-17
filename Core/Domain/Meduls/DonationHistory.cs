using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Meduls
{
    public class DonationHistory
    {
        public int Id { get; set; }

        #region Donor
        public Donor Donor { get; set; } = null!;
        public int DonerId { get; set; }
        #endregion

        #region DonationRequest
        public DonationRequest DonationRequest { get; set; } = null!;
        [Required(ErrorMessage ="PatientId Is Required")]
        public int PatieentId { get; set; }
        #endregion

        public DateTime DonationDate { get; set; }= DateTime.Now;
        public string Notes { get; set; }=null!;
    }
}
