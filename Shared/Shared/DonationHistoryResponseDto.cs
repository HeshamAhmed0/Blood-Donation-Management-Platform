using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class DonationHistoryResponseDto
    {
        #region Donor
        public int DonerId { get; set; }
        #endregion

        #region DonationRequest
        public int PatieentId { get; set; }
        #endregion

        public DateTime DonationDate { get; set; } = DateTime.Now;
        public string Notes { get; set; } = null!;
    }
}
