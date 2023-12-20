using Oops.Entities;
using Oops.Exceptions;
using Oops.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Oops.Service
{
    internal class CourierUserService:ICourierUserService
    {
        private ICourierUserRepository repository;

        public CourierUserService(ICourierUserRepository repository)
        {
            this.repository = repository;
        }
        public void TakeUserInputsAndPlaceOrder()
        {
            Console.WriteLine("Enter the weight of the courier:");
            decimal weight = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter status of the courier:");
            string status = Console.ReadLine();

            
            Console.WriteLine("Enter Date of the courier:");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter ServiceID of courier:");
            int serviceid = int.Parse(Console.ReadLine());

            // Console.WriteLine("Enter EmployeeID of courier:");
            int eid = 1;

            Console.WriteLine("Enter SenderID of courier:");
            int sid = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Reciever ID of courier:");
            int rid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Location ID of courier:");
            int lid = int.Parse(Console.ReadLine());


            Courier courier = new Courier(serviceid, eid,rid,lid, sid, weight, status, date);
            string k = repository.PlaceOrder(courier);

            if ( k!= null)
            {
               
                Console.WriteLine($"Tracking Id: {k} ");
            }
        }

        public void TakeUserInputsAndGetOrderStatus()
        {
            
                string status = "Please Enter Valid Tracking Number";
                Console.WriteLine("Enter TrackingNumber of the courier:");
                string Track = Console.ReadLine();
            if (Track != null)
            {
                try
                {
                    status = repository.GetOrderStatus(Track);
                    Console.WriteLine($"The Status of the Courier with Tracking Number:{Track} - {status}");

                }
                catch (TrackingNumberNotFoundException ex)
                {
                    Console.WriteLine($"Tracking Number Not Found Exception: {ex.Message}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
               

        }
            

        
        public void CancelOrder()
        {
            bool status = false;
            Console.WriteLine("Enter Tracking Number of the courier:");
            string Track = Console.ReadLine();
            if (Track != null)
                
            {
                try
                {
                    status = repository.CancelOrder(Track); 
                    if (status)

                    {
                        Console.WriteLine("Order successfully canceled.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to cancel the order. Please check the tracking number.");
                    }
                }
                catch (TrackingNumberNotFoundException ex)
                {
                    Console.WriteLine($"Tracking Number Not Found Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }



            }
            // Add any additional logic, validation, or business rules here
            
        }

        public void AssignCourier()
        {
            bool status = false;
            Console.WriteLine("Enter Tracking Number of the courier:");
            string Track = Console.ReadLine();


            Console.WriteLine("Enter EmployeeId to add to courier:");
            int eid = int.Parse(Console.ReadLine());
            if (Track != null && eid != null)
            {
                try
                {
                    status = repository.AssignCourier(Track, eid);

                    if (status)
                    {
                        Console.WriteLine($"Assigned Employee to the Courier.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to cancel the order. Please check the tracking number.");
                    }
                }
                catch (TrackingNumberNotFoundException ex)
                {
                    Console.WriteLine($"Tracking Number Not Found Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }



           

        }

        public void  MarkOrderDelivered()
        {
            bool status = false;
            Console.WriteLine("Enter Tracking Number of the courier:");
            string Track = Console.ReadLine();
            if (Track != null )
            {
                try
                {
                    status = repository.MarkOrderDelivered(Track);
                    if (status)
                    {
                        Console.WriteLine("Courier Marked as Delivered.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to Deliver Courier.");
                    }
                }
                catch (TrackingNumberNotFoundException ex)
                {
                    Console.WriteLine($"Tracking Number Not Found Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }



           
            
        }
        public void GetAssignedOrders()
        {
            List<string> strings = new List<string>();
           


            Console.WriteLine("Enter EmployeeId :");
            int eid = int.Parse(Console.ReadLine());
            if ( eid != null)
            {
                try
                {
                    strings = repository.GetAssignedOrders(eid);
                    if (strings.Count != 0)
                    {
                        Console.WriteLine("TrackingNumbers of the Couriers Assigned to the Employee.");
                        for (int i = 0; i < strings.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}.{strings[i]}");
                        }
                    }
                    else if (strings.Count == 0)
                    {
                        Console.WriteLine($" Employee Not Assigned to any Courier.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to load Employees");
                    }
                }
                catch (InvalidEmployeeIdException ex)
                {
                    Console.WriteLine($"Invalid Employee ID Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }



            


        }
    }
}
