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
            Console.WriteLine("Possible options:");

            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Residential");
            Console.WriteLine("2 - Commercial");


            Console.WriteLine("Enter grade: ");

            string gradeInput = Console.ReadLine();
            string grade;

            switch (gradeInput)
            {
                case "0":
                    grade = "Any";
                    break;
                case "1":
                    grade = "Residential";
                    break;
                case "2":
                    grade = "Commercial";
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    return;
            }

            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - 18 Volt");
            Console.WriteLine("2 - 24 Volt");

            Console.WriteLine("Enter voltage:");

            string voltageInput = Console.ReadLine();
            short voltage;

            switch (voltageInput)
            {
                case "0":
                    voltage = 0;
                    break;
                case "1":
                    voltage = 18;
                    break;
                case "2":
                    voltage = 24;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    return;
            }

            List<Appliance> found = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Vacuum vacuum)
                {
                    bool gradeMatches = (grade == "Any" || vacuum.Grade.Equals(grade, StringComparison.OrdinalIgnoreCase));
                    bool voltageMatches = (voltage == 0 || vacuum.BatteryVoltage == voltage);

                    if (gradeMatches && voltageMatches)
                    {
                        found.Add(vacuum);
                    }
                }
            }
            DisplayAppliancesFromList(found, 0);
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
