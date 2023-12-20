using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops.Exceptions
{
    internal class TrackingNumberNotFoundException:Exception
    {
        public TrackingNumberNotFoundException(string trackingNumber)
        : base($"Tracking number '{trackingNumber}' not found.")
        {
        }
    }
}
