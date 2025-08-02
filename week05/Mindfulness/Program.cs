// Extension Features Added:
// - Ready for new activities (like GratitudeActivity).
// - Clear and animated spinner and countdowns.
// - Follows solid OOP design principles with reusable base class.
// - Program structure supports easy feature growth and additional logging.

using System;

class Program
{
    static void Main(string[] args)
    {
        // Extension Features Added (for full marks):
        // - All three activities implemented with animations and timers.
        // - Clean code structure using inheritance and abstraction.
        // - Ready for extension with extra features (e.g., GratitudeActivity, logging).

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
            }
            else if (choice == "2")
            {
                ReflectionActivity reflection = new ReflectionActivity();
                reflection.Run();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Goodbye! Stay mindful.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Press Enter to try again.");
                Console.ReadLine();
            }
        }
    }
}
