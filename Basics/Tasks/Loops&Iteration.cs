using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Tasks
{
    internal class Loops_Iteration
    {
        // 1. Display all the orders for a specific customer using a for loop
        public void DisplayOrdersForCustomer(string customerName)
        {
            Console.WriteLine($"Orders for {customerName}:");

            // Simulating data for orders
            for (int orderNumber = 1; orderNumber <= 5; orderNumber++)
            {
                Console.WriteLine($"Order {orderNumber}");
            }

            Console.WriteLine();
        }

        // 2. Track the real-time location of a courier until it reaches its destination using a while loop
        public void TrackCourierLocation()
        {
            Console.WriteLine("Tracking courier in real-time:");

            
            int distanceToDestination = 100; 
            int currentLocation = 0;

            while (currentLocation < distanceToDestination)
            {
                Console.WriteLine($"Courier is at location {currentLocation} km.");

                //  courier movement
                currentLocation += 10; 

                
            }

            Console.WriteLine("Courier has reached its destination.");

            Console.WriteLine();
        }
    }
}
