using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Basics.Tasks
{
    internal class Strings_2D_Hashmaps
    {
        // 1. Parcel Tracking
        public void TrackParcelStatus(string[,] parcelTrackingArray, string trackingNumber)
        {
            for (int i = 0; i < parcelTrackingArray.GetLength(0); i++)
            {
                if (parcelTrackingArray[i, 0] == trackingNumber)
                {
                    Console.WriteLine($"Tracking Status: {parcelTrackingArray[i, 1]}");
                    return;
                }
            }

            Console.WriteLine("Parcel not found in tracking system.");
        }

        // 2. Customer Data Validation
        public void ValidateCustomerInformation(string name, string address, string phoneNumber)
        {
            if (IsValidName(name))
            {
                Console.WriteLine("Name is valid.");
            }
            else
            {
                Console.WriteLine("Invalid name format.");
            }

            if (IsValidAddress(address))
            {
                Console.WriteLine("Address is valid.");
            }
            else
            {
                Console.WriteLine("Invalid address format.");
            }

            if (IsValidPhoneNumber(phoneNumber))
            {
                Console.WriteLine("Phone number is valid.");
            }
            else
            {
                Console.WriteLine("Invalid phone number format.");
            }
            
            Console.WriteLine("Validation Successful");
        }
        static bool IsValidName(string name)
        {
            // Ensure that names contain only letters and are properly capitalized
            return Regex.IsMatch(name, "^[A-Za-z]+( [A-Za-z]+)*$");
        }

        static bool IsValidAddress(string address)
        {
            // Ensure that addresses do not contain special characters
            return Regex.IsMatch(address, "^[A-Za-z0-9\\s]+$");
        }

        static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Ensure that phone numbers follow a specific format (e.g., ###-###-####)
            return Regex.IsMatch(phoneNumber, "^[0-9]{3}-[0-9]{3}-[0-9]{4}$");
        }

        // 3. Address Formatting
        public string FormatAddress(string street, string city, string state, string zipCode)
        {
            // Implement formatting logic
            return $"{char.ToUpper(street[0]) + street.Substring(1)}, {char.ToUpper(city[0]) + city.Substring(1)}, {state.ToUpper()}, {zipCode}";
        }

        // 4. Order Confirmation Email
        public void GenerateOrderConfirmationEmail(string customerName, string orderNumber, string deliveryAddress, string expectedDeliveryDate)
        {
            string emailContent = $"Dear {customerName},\n\nYour order ({orderNumber}) is confirmed. It will be delivered to {deliveryAddress} by {expectedDeliveryDate}.\n\nThank you for choosing our services!";
            Console.WriteLine($"Order Confirmation Email:\n\n{emailContent}");
        }

        // 5. Calculate Shipping Costs
        public double CalculateShippingCost(string sourceAddress, string destinationAddress, double parcelWeight)
        {
            double distance = 10;//CalculateDistance(sourceAddress, destinationAddress);

            // Shipping cost calculation based on distance and weight
            double baseCost = 5.0; // Base cost per kilometer
            return baseCost * distance * parcelWeight;
            
            
        }

        // 6. Password Generator
        public string GeneratePassword()
        {
            
            const string uppercaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercaseLetters = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";
            const string specialCharacters = "!@#$%^&*()_+-=[]{}|;:'\",.<>/?";

            const int minLength = 8;
            const int maxLength = 12;

            StringBuilder password = new StringBuilder();

            Random random = new Random();

            // Ensure the password contains at least one character from each category
            password.Append(uppercaseLetters[random.Next(uppercaseLetters.Length)]);
            password.Append(lowercaseLetters[random.Next(lowercaseLetters.Length)]);
            password.Append(numbers[random.Next(numbers.Length)]);
            password.Append(specialCharacters[random.Next(specialCharacters.Length)]);

            // Randomly select additional characters from all categories to meet the desired length
            int remainingLength = random.Next(minLength - 4, maxLength - 4);
            for (int i = 0; i < remainingLength; i++)
            {
                string allCharacters = uppercaseLetters + lowercaseLetters + numbers + specialCharacters;
                password.Append(allCharacters[random.Next(allCharacters.Length)]);
            }

            // Shuffle the password characters
            char[] passwordArray = password.ToString().ToCharArray();
            for (int i = passwordArray.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                char temp = passwordArray[i];
                passwordArray[i] = passwordArray[j];
                passwordArray[j] = temp;
            }

            return new string(passwordArray);
          
        }

        // 7. Find Similar Addresses
        public void FindSimilarAddresses(List<string> addresses)
        {
            HashSet<string> uniqueAddresses = new HashSet<string>();
            HashSet<string> duplicateAddresses = new HashSet<string>();

            foreach (string address in addresses)
            {
                if (!uniqueAddresses.Add(address))
                {
                    duplicateAddresses.Add(address);
                }
            }

            Console.WriteLine("Duplicate Addresses:");
            foreach (string duplicateAddress in duplicateAddresses)
            {
                Console.WriteLine(duplicateAddress);
            }
        }
    }
}
