using Oops.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops.Repository
{
    internal interface ICourierAdminRepository
    {
        // Add a new courier staff member to the system.
        // Returns the ID of the newly added courier staff member.
        int AddCourierStaff(Employee employeeObj);

        // Remove a courier staff member from the system.
        // Returns true if the staff member was successfully removed, false otherwise.
       bool RemoveCourierStaff(int courierStaffId);

        string GenerateDeliveryReport(DateTime startDate, DateTime endDate);

        // Generate a report of orders delivered within a specified date range.
        // Returns a report containing information about delivered orders within the date range.
        // string GenerateDeliveryReport(DateTime startDate, DateTime endDate);
    }
}
