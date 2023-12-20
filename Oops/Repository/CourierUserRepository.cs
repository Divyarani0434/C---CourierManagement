using Oops.Entities;
using Oops.Utility;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oops.Exceptions;

namespace Oops.Repository
{
    internal class CourierUserRepository :ICourierUserRepository
    {
        public string connectionString;
        SqlCommand cmd = null;

        //constructor
        public CourierUserRepository()
        {

            //  sqlConnection = new SqlConnection("Server=DESKTOP-0TE71RT;Database=PRODUCTAPPDB;Trusted_Connection=True");
            connectionString = DbConn.GetConnectionString();
            cmd = new SqlCommand();
        }

       

        public string PlaceOrder(Courier courierObj)
        {
            string trackingNumber = GenerateUniqueTrackingNumber();
            courierObj.TrackingNumber = trackingNumber;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int ki = 0;
                connection.Open();

                // Example: Insert the courier order into the database
                string insertCourierQuery = "INSERT INTO Couriers (Weight, Status, TrackingNumber, DeliveryDate, ServiceID, EmployeeID, RecieverID, LocationID, SenderID) " +
                                        "VALUES (@Weight, @Status, @TrackingNumber, @DeliveryDate, @ServiceID, @EmployeeID, @RecieverID, @LocationID, @SenderID)";
                using (SqlCommand command = new SqlCommand(insertCourierQuery, connection))
                {
                    command.Parameters.AddWithValue("@Weight", courierObj.Weight);
                    command.Parameters.AddWithValue("@Status", courierObj.Status);
                    command.Parameters.AddWithValue("@TrackingNumber", courierObj.TrackingNumber);
                    command.Parameters.AddWithValue("@DeliveryDate", courierObj.DeliveryDate);
                    command.Parameters.AddWithValue("@ServiceID", courierObj.ServiceID);
                    command.Parameters.AddWithValue("@EmployeeID", courierObj.EmployeeID);
                    command.Parameters.AddWithValue("@RecieverID", courierObj.RecieverID);
                    command.Parameters.AddWithValue("@LocationID", courierObj.LocationID);
                    command.Parameters.AddWithValue("@SenderID", courierObj.SenderID);

                     ki =command.ExecuteNonQuery();

                }
                if (ki > 0)
                {
                    Console.WriteLine("Courier placed Successfully");

                    return trackingNumber;
                }
                else
                {
                    return null;
                }
                
                
                
            }
        }

        public string GetOrderStatus(string trackingNumber)
        {
            string status = "Unknown"; // Default status if not found
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Status FROM Couriers WHERE TrackingNumber = @TrackingNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                status = reader["Status"].ToString();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new TrackingNumberNotFoundException($"Tracking number '{trackingNumber}' not found.");

            }
            return status;
        }

        public bool CancelOrder(string trackingNumber)
        {
            bool isCanceled = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Couriers WHERE TrackingNumber = @TrackingNumber";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

                    int rowsAffected = command.ExecuteNonQuery();

                    isCanceled = rowsAffected > 0;
                }
            }

            return isCanceled;
        }

        public bool AssignCourier(string trackingNumber, int employeeId)
        {
            bool isAssigned = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Couriers SET EmployeeID = @eid WHERE TrackingNumber = @TrackingNumber";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@eid", employeeId);
                    command.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

                    int rowsAffected = command.ExecuteNonQuery();

                    isAssigned = rowsAffected > 0;
                }
            }

            return isAssigned;
        }

        public bool MarkOrderDelivered(string trackingNumber)
        {
            bool isMarkedDelivered = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Couriers SET DeliveryDate = GETDATE(),Status ='Delivered' WHERE TrackingNumber = @TrackingNumber";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

                    int rowsAffected = command.ExecuteNonQuery();

                    isMarkedDelivered = rowsAffected > 0;
                }
            }

            return isMarkedDelivered;
        }

        public List<string> GetAssignedOrders(int employeeId)
        {
            List<string> assignedOrders = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT TrackingNumber FROM Couriers WHERE EmployeeID = @eid";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@eid", employeeId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            assignedOrders.Add(reader["TrackingNumber"].ToString());
                        }
                    }
                }
            }

            return assignedOrders;
        }
        private string GenerateUniqueTrackingNumber()
        {
            
            return $"{DateTime.Now.Ticks}";
        }

    }
}
