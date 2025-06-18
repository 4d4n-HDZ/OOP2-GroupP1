using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "

            // Create long variable to hold item number

            // Get user input as string and assign to variable.
            // Convert user input from string to long and store as item number variable.

            // Create 'foundAppliance' variable to hold appliance with item number
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)

            // Loop through Appliances
                // Test appliance item number equals entered item number
                    // Assign appliance in list to foundAppliance variable

                    // Break out of loop (since we found what need to)

            // Test appliance was not found (foundAppliance is null)
                // Write "No appliances found with that item number."

            // Otherwise (appliance was found)
                // Test found appliance is available
                    // Checkout found appliance

                    // Write "Appliance has been checked out."
                // Otherwise (appliance isn't available)
                    // Write "The appliance is not available to be checked out."
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            Console.Write("Enter brand to search for: ");
            string? brandInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(brandInput))
            {
                Console.WriteLine("Brand cannot be empty.");
                return;
            }

            List<Appliance> found = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance.Brand != null &&
                appliance.Brand.Equals(brandInput, StringComparison.OrdinalIgnoreCase))
                {
                    found.Add(appliance);
                }
            }

            if (found.Count == 0)
            {
                Console.WriteLine("No appliances found with that brand.");
            }
            else
            {
                DisplayAppliancesFromList(found, 0); 
            }
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
    Console.Write("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors): ");
    string input = Console.ReadLine();
    Console.WriteLine();

    if (!int.TryParse(input, out int doors))
    {
        Console.WriteLine("Invalid option.");
        Console.WriteLine();
        return;
    }

    var found = new List<Appliance>();
    foreach (var a in Appliances)
    {
        if (a is Refrigerator r && (doors == 0 || r.Doors == doors))
            found.Add(r);
    }

    Console.WriteLine("Matching Refrigerators:\n");
    DisplayAppliancesFromList(found, 0);
}

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - Residential"
            // Write "2 - Commercial"

            // Write "Enter grade:"

            // Get user input as string and assign to variable

            // Create grade variable to hold grade to find (Any, Residential, or Commercial)

            // Test input is "0"
                // Assign "Any" to grade
            // Test input is "1"
                // Assign "Residential" to grade
            // Test input is "2"
                // Assign "Commercial" to grade
            // Otherwise (input is something else)
                // Write "Invalid option."

                // Return to calling (previous) method
                // return;

            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - 18 Volt"
            // Write "2 - 24 Volt"

            // Write "Enter voltage:"

            // Get user input as string
            // Create variable to hold voltage

            // Test input is "0"
                // Assign 0 to voltage
            // Test input is "1"
                // Assign 18 to voltage
            // Test input is "2"
                // Assign 24 to voltage
            // Otherwise
                // Write "Invalid option."
                // Return to calling (previous) method
                // return;

            // Create found variable to hold list of found appliances.

            // Loop through Appliances
                // Check if current appliance is vacuum
                    // Down cast current Appliance to Vacuum object
                    // Vacuum vacuum = (Vacuum)appliance;

                    // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
                        // Add current appliance in list to found list

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
        }

        public override void DisplayMicrowaves()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Kitchen");
            Console.WriteLine("2 - Work site");
            Console.Write("Enter room type: ");

            string? input = Console.ReadLine()?.Trim();
            char roomType;

            if (input == "0")
            {
                roomType = 'A'; 
            }
            else if (input == "1")
            {
                roomType = Microwave.RoomTypeKitchen; 
            }
            else if (input == "2")
            {
                roomType = Microwave.RoomTypeWorkSite; 
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            var found = new List<Appliance>();

            foreach (var appliance in Appliances)
            {
                if (appliance is Microwave microwave)
                {
                    if (roomType == 'A' || microwave.RoomType == roomType)
                    {
                        found.Add(microwave);
                    }
                }
            }

            DisplayAppliancesFromList(found, 0);
        }
        

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - Quietest"
            // Write "2 - Quieter"
            // Write "3 - Quiet"
            // Write "4 - Moderate"

            // Write "Enter sound rating:"

            // Get user input as string and assign to variable

            // Create variable that holds sound rating

            // Test input is "0"
                // Assign "Any" to sound rating variable
            // Test input is "1"
                // Assign "Qt" to sound rating variable
            // Test input is "2"
                // Assign "Qr" to sound rating variable
            // Test input is "3"
                // Assign "Qu" to sound rating variable
            // Test input is "4"
                // Assign "M" to sound rating variable
            // Otherwise (input is something else)
                // Write "Invalid option."
                // Return to calling method

            // Create variable that holds list of found appliances

            // Loop through Appliances
                // Test if current appliance is dishwasher
                    // Down cast current Appliance to Dishwasher

                    // Test sound rating is "Any" or equals soundrating for current dishwasher
                        // Add current appliance in list to found list

            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
                {
            Console.Write("Enter number of appliances: ");
            string numInput = Console.ReadLine();
            Console.WriteLine();

            if (!int.TryParse(numInput, out int count) || count < 1)
            {
                Console.WriteLine("Invalid number.\n");
                return;
            }

            if (count > Appliances.Count)
                count = Appliances.Count;

            var rnd = new Random();
            var available = new List<Appliance>(Appliances);

            Console.WriteLine($"\nRandom {count} appliance(s):\n");
            for (int i = 0; i < count; i++)
            {
                int idx = rnd.Next(available.Count);
                Console.WriteLine(available[idx]);
                Console.WriteLine();
                available.RemoveAt(idx);
            }
        }
    }
}
