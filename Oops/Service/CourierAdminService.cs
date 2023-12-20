using Oops.Entities;
using Oops.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops.Service
{
    internal class CourierAdminService :ICourierAdminService
    {
        private ICourierAdminRepository repository;

        public CourierAdminService(ICourierAdminRepository repository)
        {
            this.repository = repository;
        }
        public void AddCourierStaff()
        {
            Console.WriteLine("Enter Name of Employee:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter email of the Employee:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Contact Number of the Employee:");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter Role of the Employee:");
            string role = Console.ReadLine();
            Console.WriteLine("Enter Salary of the Employee:");
            decimal sal = decimal.Parse(Console.ReadLine());
                                   
            Employee employee = new Employee(name, email, phone, role, sal);
            int k = repository.AddCourierStaff(employee);

            if (k > 0)
            {

                Console.WriteLine($"Employee Added Successfully with EmployeeID: {k} ");
            }
        }
        public void RemoveCourierStaff()
        {
            bool status = false;
            Console.WriteLine("Enter Tracking Number of the courier:");
            int Track = int.Parse(Console.ReadLine());
            if (Track != null)
            {
                status = repository.RemoveCourierStaff(Track);


            }
            // Add any additional logic, validation, or business rules here
            if (status)
            {
                Console.WriteLine("Employee successfully Removed.");
            }
            else
            {
                Console.WriteLine("Failed to cremove Employee.");
            }
        }
        public void DeliveryReport()
        {
            string result = "0 Couriers of Orders are present within the Specified timerange ";
            Console.WriteLine("Enter the Range of Dates to find the Orders and Generate Report");
            Console.WriteLine("Enter StartDate Date :");
            DateTime sdate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter EndDate Date :");
            DateTime edate = DateTime.Parse(Console.ReadLine());
            if (sdate < edate && sdate != null && edate != null){
                result = repository.GenerateDeliveryReport(sdate, edate);
                
            }
            Console.WriteLine($"Generated Report : \n {result}");
        }
    }
}
