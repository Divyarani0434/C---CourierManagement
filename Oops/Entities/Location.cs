using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops.Entities { 
    internal class Location
    {
        private static long nextLocationID = 1;

        public Location()
        {
            LocationID = nextLocationID++;
        }

        public long LocationID { get; private set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
    }
}
 