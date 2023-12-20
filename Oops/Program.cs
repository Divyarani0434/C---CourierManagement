using Oops.Repository;
using Oops.Service;
using System;

class Program
{
    static void Main()
    {
        var repository = new CourierUserRepository();
        var repository1 = new CourierAdminRepository();
        var courierService = new CourierUserService(repository);
        var courierAdmin = new CourierAdminService(repository1);


        Console.WriteLine("Courier Management System");
    MainMenu:
        while (true)
        {
            Console.WriteLine("Main Menu :");
            Console.WriteLine("1. User Options");
            Console.WriteLine("2. Admin Options");
            Console.WriteLine("Choose an operation:");



            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    while (true)
                    {

                        Console.WriteLine("1. Place a new courier order");
                        Console.WriteLine("2. Get order status");
                        Console.WriteLine("3. Cancel a Courier");
                        Console.WriteLine("4. Assign Employee to Courier");
                        Console.WriteLine("5. Mark Courier Delivered");
                        Console.WriteLine("6. Check Couries Assigned to Employee ");
                        Console.WriteLine("7. Return To Main Menu ");
                        Console.WriteLine("Choose an operation:");

                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                courierService.TakeUserInputsAndPlaceOrder();
                                break;
                            case "2":
                                // Add a new courier staff member
                                courierService.TakeUserInputsAndGetOrderStatus();
                                break;

                            case "3":
                                // Get order status
                                courierService.CancelOrder();
                                break;

                            case "4":
                                courierService.AssignCourier();

                                break;
                            case "5":
                                courierService.MarkOrderDelivered();

                                break;
                            case "6":
                                courierService.GetAssignedOrders();
                                break;
                            case "7":
                                goto MainMenu;

                            default:
                                Console.WriteLine("Invalid choice. Please enter a valid option.");
                                break;
                        }
                        Console.WriteLine();

                    }
                    break;

                case "2":
                    while (true)
                    {
                        Console.WriteLine("1. Add Courier Employee");
                        Console.WriteLine("2. Remove Courier Employee");
                        Console.WriteLine("3. Generate Delivery Report");
                        Console.WriteLine("4. Return To Main Menu ");
                        Console.WriteLine("Choose an operation:");

                        string input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                courierAdmin.AddCourierStaff();
                                break;
                            case "2":
                                // Add a new courier staff member
                                courierAdmin.RemoveCourierStaff();
                                break;

                            case "3":
                                // Get delivery Report
                                courierAdmin.DeliveryReport();
                                break;

                            case "4":
                                goto MainMenu;
                            default:
                                Console.WriteLine("Invalid choice. Please enter a valid option.");
                                break;
                        }
                        Console.WriteLine();

                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
