using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions.DonationHistory
{
    public class DonationHistoryRequestDatabaseException() :DonationHistoryException("Exception Occuer While Saving Data In Database")
    {
    }
}
