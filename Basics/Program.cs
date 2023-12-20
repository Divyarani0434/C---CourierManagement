using Basics;
using Basics.Tasks;




////ControlFlow Statements/////
Controlflow controlflow  = new Controlflow();
// 1. Check Order Delivery Status
controlflow.CheckOrderDeliveryStatus();
// 2. Categorize Parcels based on Weight
controlflow.CategorizeParcels();
// 3. User Authentication
controlflow.UserAuthentication();
// 4. Courier Assignment Logic
controlflow.CourierAssignmentLogic(); 


////Loops and Iterations/////
Loops_Iteration loops_Iteration = new Loops_Iteration();
//1.Display Order Based on Customer
loops_Iteration.DisplayOrdersForCustomer("Divya");
//2.Track Courier Location
loops_Iteration.TrackCourierLocation();

///Arrays and DataStructures///
Arrays_DS arrays_DS = new Arrays_DS();

Arrays_DS.Courier[] couriers = arrays_DS.InitializeCouriers();

// 3. Utilize arrays to store the tracking history of a parcel
int[] parcelTrackingHistory = new int[10]; // Replace with actual size
arrays_DS.TrackParcelLocation(parcelTrackingHistory);

// 4. Implement a method to find the nearest available courier for a new order using an array of couriers
Arrays_DS.Courier nearestCourier = arrays_DS.FindNearestCourier(couriers, "LocationX"); // Replace with actual location
Console.WriteLine($"The nearest available courier is {nearestCourier.Name}.");


///5: Strings,2d Arrays, user defined functions,Hashmap////
Strings_2D_Hashmaps strings_2D_Hashmaps = new Strings_2D_Hashmaps();

// 1. Parcel Tracking
string[,] parcelTrackingArray = {
            {"123456", "Parcel in transit"},
            {"789012", "Parcel out for delivery"},
            {"345678", "Parcel delivered"}
        };

Console.Write("Enter parcel tracking number: ");
string trackingNumber = Console.ReadLine();
strings_2D_Hashmaps.TrackParcelStatus(parcelTrackingArray, trackingNumber);

// 2. Customer Data Validation
strings_2D_Hashmaps.ValidateCustomerInformation("John Doe", "123 Main St", "555-1234");

// 3. Address Formatting
string formattedAddress = strings_2D_Hashmaps.FormatAddress("123 elm street", "cityville", "state", "12345");
Console.WriteLine($"Formatted Address: {formattedAddress}");

// 4. Order Confirmation Email
strings_2D_Hashmaps.GenerateOrderConfirmationEmail("John Doe", "Order123", "456 Main St", "Expected Date: 2023-01-01");

// 5. Calculate Shipping Costs
double shippingCost = strings_2D_Hashmaps.CalculateShippingCost("SourceAddress", "DestinationAddress", 5.0);
Console.WriteLine($"Shipping Cost: ${shippingCost}");

// 6. Password Generator
string generatedPassword = strings_2D_Hashmaps.GeneratePassword();
Console.WriteLine($"Generated Password: {generatedPassword}");

// 7. Find Similar Addresses
strings_2D_Hashmaps.FindSimilarAddresses(new List<string> { "123 Main St", "456 Elm St", "789 Oak St", "123 Main St" });





