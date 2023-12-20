using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops.Exceptions
{
    internal class InvalidEmployeeIdException:Exception
    {
        public InvalidEmployeeIdException(string trackingNumber)
        : base($"Tracking number '{trackingNumber}' not found.")
        {
        }
    }
}
