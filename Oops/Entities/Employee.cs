using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops.Entities
{
    internal class Employee
    {
        private static long nextEmployeeID = 1;

        public Employee()
        {
            EmployeeID = nextEmployeeID++;
        }

        public Employee(string name, string email, string phone, string role, decimal sal)
        {
            EmployeeName = name;
            Email = email;
            ContactNumber = phone;
            Role = role;
            Salary = sal;
        }

        public long EmployeeID { get; private set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Role { get; set; }
        public decimal Salary { get; set; }
        public string? Name { get; }
        public string? Phone { get; }
        public decimal Sal { get; }
    }
}
