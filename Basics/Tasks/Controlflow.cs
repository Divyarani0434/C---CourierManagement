using System;

internal class Controlflow
{
    
        
    

    // 1. Check Order Delivery Status
    public  void CheckOrderDeliveryStatus()
    {
        string orderStatus = "Delivered"; 

        if (orderStatus.Equals("Delivered"))
        {
            Console.WriteLine("The order has been delivered.");
        }
        else if (orderStatus.Equals("Processing"))
        {
            Console.WriteLine("The order is still being processed.");
        }
        else if (orderStatus.Equals("Cancelled"))
        {
            Console.WriteLine("The order has been cancelled.");
        }
        else
        {
            Console.WriteLine("Invalid order status.");
        }

        Console.WriteLine();
    }

    // 2. Categorize Parcels based on Weight
    public  void CategorizeParcels()
    {
        double parcelWeight = 15.0; 

        switch ((int)parcelWeight)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                Console.WriteLine("Light parcel.");
                break;
            case 4:
            case 5:
            case 6:
                Console.WriteLine("Medium parcel.");
                break;
            default:
                Console.WriteLine("Heavy parcel.");
                break;
        }

        Console.WriteLine();
    }

    // 3. User Authentication
    public  void UserAuthentication()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        if (AuthenticateUser(username, password))
        {
            Console.WriteLine("Login successful.");
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
        }

        Console.WriteLine();
    }

    public  bool AuthenticateUser(string username, string password)
    {
        return username.Equals("admin") && password.Equals("password123");
    }

    // 4. Courier Assignment Logic
    public  void CourierAssignmentLogic()
    {
        int totalCouriers = 5; // Replace with actual number of couriers
        int shipmentsToAssign = 10; // Replace with actual number of shipments

        for (int shipment = 1; shipment <= shipmentsToAssign; shipment++)
        {
            Console.WriteLine($"Assigning courier for shipment {shipment}");

            int assignedCourierId = AssignCourier(totalCouriers);

            if (assignedCourierId != -1)
            {
                Console.WriteLine($"Courier {assignedCourierId} assigned for shipment {shipment}");
            }
            else
            {
                Console.WriteLine("No available couriers. Shipment delayed.");
            }

            Console.WriteLine();
        }
    }

    public int AssignCourier(int totalCouriers)
    {
        Random random = new Random();
        return random.Next(1, totalCouriers + 1);
    }
}

