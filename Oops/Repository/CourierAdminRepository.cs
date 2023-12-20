using Oops.Entities;
using Oops.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops.Repository
{
    internal class CourierAdminRepository :ICourierAdminRepository
    {
        public string connectionString;
        SqlCommand cmd = null;

        //constructor
        public CourierAdminRepository()
        {

            //  sqlConnection = new SqlConnection("Server=DESKTOP-0TE71RT;Database=PRODUCTAPPDB;Trusted_Connection=True");
            connectionString = DbConn.GetConnectionString();
            cmd = new SqlCommand();
        }
        public int AddCourierStaff(Employee employee)
        {
            int newCourierStaffId = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Employee (Name, Email, ContactNumber, Role, Salary) " +
                               "VALUES (@Name, @Email, @ContactNumber, @Role, @Salary);" +
                               "SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", employee.EmployeeName);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@ContactNumber", employee.ContactNumber);
                    command.Parameters.AddWithValue("@Role", employee.Role);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);

                    newCourierStaffId = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return newCourierStaffId;
        }
        public bool RemoveCourierStaff(int courierStaffId)
        {
            bool isRemoved = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Employee WHERE EmployeeID = @CourierStaffId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourierStaffId", courierStaffId);

                    int rowsAffected = command.ExecuteNonQuery();
                    isRemoved = rowsAffected > 0;
                }
            }

            return isRemoved;
        }

        public string GenerateDeliveryReport(DateTime startDate, DateTime endDate)
        {
            string report = string.Empty;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT O.OrderID, O.CourierID, O.OrderDate, C.Status " +
                               "FROM Orders O " +
                               "JOIN Couriers C ON O.CourierID = C.CourierID " +
                               "WHERE O.OrderDate >= @StartDate AND O.OrderDate <= @EndDate AND C.Status = 'Delivered'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int orderId = reader.GetInt32(0);
                            int courierId = reader.GetInt32(1);
                            DateTime orderDate = reader.GetDateTime(2);
                            string courierStatus = reader.GetString(3);

                            // Customize the report format based on your needs
                            report += $"OrderID: {orderId}, CourierID: {courierId}, OrderDate: {orderDate}, Status: {courierStatus}\n";
                        }
                    }
                }
            }

            return report;
        }


    }
}
