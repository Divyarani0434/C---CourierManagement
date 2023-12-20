using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oops.Entities;

namespace Oops.Repository
{
    internal interface ICourierUserRepository
    {
        // Returns the unique tracking number for the courier order.
        string PlaceOrder(Courier courierObj);

        // Get the status of a courier order.
        // Returns the status of the courier order (e.g., yetToTransit, In Transit, Delivered).
        string GetOrderStatus(string trackingNumber);

        // Cancel a courier order.
        // Returns true if the order was successfully canceled, false otherwise.
        bool CancelOrder(string trackingNumber);

        // Courier Staff-related functions

        // Assign a courier staff member to deliver an order.
        // Returns true if the assignment was successful, false otherwise.
        bool AssignCourier(string trackingNumber, int courierStaffId);

        // Mark an order as delivered.
        // Returns true if the order was successfully marked as delivered, false otherwise.
        bool MarkOrderDelivered(string trackingNumber);

        // Get a list of orders assigned to a specific courier staff member.
        // Returns a list of courier orders assigned to the staff member.
        List<string> GetAssignedOrders(int courierStaffId);
    }
}
