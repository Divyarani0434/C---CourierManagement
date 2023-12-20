using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Tasks
{
    internal class Arrays_DS
    {
        // Simulating data structure for a Courier
        public class Courier
        {
            public string Name { get; set; }
            public string Location { get; set; }
        }
        // Simulating initialization of couriers
        public Courier[] InitializeCouriers()
        {
            return new Courier[]
            {
            new Courier { Name = "Courier1", Location = "LocationA" },
            new Courier { Name = "Courier2", Location = "LocationB" },
            new Courier { Name = "Courier3", Location = "LocationC" }
            
            };
        }

        // 3. Utilize arrays to store the tracking history of a parcel
        public void TrackParcelLocation(int[] parcelTrackingHistory)
        {
            Console.WriteLine("Tracking parcel location history:");

           
            for (int i = 0; i < parcelTrackingHistory.Length; i++)
            {
                parcelTrackingHistory[i] = i * 10; 
                Console.WriteLine($"Update {i + 1}: Parcel is at location {parcelTrackingHistory[i]} km.");
            }

            Console.WriteLine();
        }

        // 4. Implement a method to find the nearest available courier for a new order using an array of couriers
        public Courier FindNearestCourier(Courier[] couriers, string orderLocation)
        {
            double minDistance = double.MaxValue;
            Courier nearestCourier = null;

            foreach (Courier courier in couriers)
            {
                double distance = CalculateDistance(courier.Location, orderLocation);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestCourier = courier;
                }
            }

            return nearestCourier;
        }

        // Simulating a method to calculate distance between two locations
        static double CalculateDistance(string location1, string location2)
        {
            // Replace with actual distance calculation logic
            return Math.Abs(location1.Length - location2.Length);
        }

    }
}
