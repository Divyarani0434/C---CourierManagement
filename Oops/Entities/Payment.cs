using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops.Entities
{
    internal class Payment
    {
        private static long nextPaymentID = 1;

        public Payment()
        {
            PaymentID = nextPaymentID++;
        }

        public long PaymentID { get; private set; }
        public long CourierID { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
    