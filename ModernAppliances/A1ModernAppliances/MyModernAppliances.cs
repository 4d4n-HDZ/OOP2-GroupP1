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
    Console.Write("Enter the item number of an appliance: ");

    string input = Console.ReadLine().Trim();

    bool success = long.TryParse(input, out long itemNumber);

    if (!success)
    {
        Console.WriteLine("Invalid item number format.");
        return;
    }

    Appliance? foundAppliance = null;

    foreach (Appliance appliance in Appliances)
    {
        if (appliance.ItemNumber == itemNumber)
        {
            foundAppliance = appliance;
            break;
        }
    }
    if (foundAppliance == null)
    {
        Console.WriteLine("No appliances found with that item number.");
    }
    else
    {
        if (foundAppliance.Quantity > 0)
        {
            foundAppliance.Checkout();
            Console.WriteLine($"Appliance \"{foundAppliance.ItemNumber}\" has been checked out.");
        }
        else
        {
            Console.WriteLine("The appliance is not available to be checked out.");
        }
    }
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
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Quietest");
            Console.WriteLine("2 - Quieter");
            Console.WriteLine("3 - Quiet");
            Console.WriteLine("4 - Moderate");

            Console.Write("Enter sound rating: ");

            string input = Console.ReadLine().Trim();

            string selectedRating;

            if (input == "0")
            {
                selectedRating = "Any";
            }
            else if (input == "1")
            {
                selectedRating = Dishwasher.SoundRatingQuietest;
            }
            else if (input == "2")
            {
                selectedRating = Dishwasher.SoundRatingQuieter;
            }
            else if (input == "3")
            {
                selectedRating = Dishwasher.SoundRatingQuiet;
            }
            else if (input == "4")
            {
                selectedRating = Dishwasher.SoundRatingModerate;
            }
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }
            List<Appliance> found = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Dishwasher dishwasher)
                {
                    if (selectedRating == "Any" || dishwasher.SoundRating == selectedRating)
                    {
                        found.Add(dishwasher);
                    }
                }
            }
            DisplayAppliancesFromList(found, 0);
        }

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
