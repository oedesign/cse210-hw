using System;

class Program
{
    static void Main(string[] args)
    {
        var manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Eternal Quest Menu ---");
            Console.WriteLine($"Current Score: {manager.Score}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;
                case "2":
                    manager.ListGoals();
                    break;
                case "3":
                    manager.SaveGoals();
                    break;
                case "4":
                    manager.LoadGoals();
                    break;
                case "5":
                    manager.RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}

/*
EXCEEDING REQUIREMENTS:
- Level System: player gains a level every 1000 points.
- Negative Goals: track bad habits that subtract points when recorded.
- Achievement messages for milestone scores.
These extra features are implemented to demonstrate creativity beyond the core requirements.
*/
