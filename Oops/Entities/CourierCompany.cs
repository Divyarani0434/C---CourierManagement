using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops.Entities
{
    internal class CourierCompany
    {
        public string CompanyName { get; set; }
        public Courier[] CourierDetails { get; set; }
        public Employee[] EmployeeDetails { get; set; }
        public Location[] LocationDetails { get; set; }
    }
}
   

