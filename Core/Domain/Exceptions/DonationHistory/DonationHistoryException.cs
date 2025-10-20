using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.DonationHistory
{
    public class DonationHistoryException(string message) :Exception(message)
    {
    }
}
