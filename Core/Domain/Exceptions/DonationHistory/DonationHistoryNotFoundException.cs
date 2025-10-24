using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.DonationHistory
{
    public class DonationHistoryNotFoundException : DonationHistoryException
    {
        public DonationHistoryNotFoundException(int id) : base($"Donation History With Id {id} Not Found")
        {
        }
        public DonationHistoryNotFoundException() : base("There Are Not Any Donation History")
        {
        }
    }
}
