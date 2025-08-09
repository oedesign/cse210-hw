using System;
using System.Collections.Generic;
using System.IO;

// Extra Credit Features:
// 1. Leveling System: Level up every 500 points with fun titles.
// 2. Milestone Celebrations at 1000, 2000, etc.
// 3. Titles change with level: Apprentice, Adventurer, Quest Master, Ninja Unicorn.

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int totalPoints = 0;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            DisplayPlayerStats();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void DisplayPlayerStats()
    {
        int level = totalPoints / 500 + 1;
        string title = GetPlayerTitle(level);
        Console.WriteLine($"\nYou are Level {level} - \"{title}\" with {totalPoints} points!\n");
    }

    static string GetPlayerTitle(int level)
    {
        if (level < 2) return "Apprentice";
        if (level < 4) return "Adventurer";
        if (level < 6) return "Quest Master";
        return "Ninja Unicorn";
    }

    static void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("Enter the name of your goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a short description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points associated with this goal: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for completing it? ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, description, points, target, 0, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("\nYour goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetailsString()}");
        }
        Console.WriteLine();
    }

    static void SaveGoals()
    {
        Console.Write("Enter the filename to save to: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(totalPoints);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    static void LoadGoals()
    {
        Console.Write("Enter the filename to load from: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            totalPoints = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(":");
                string type = parts[0];
                string[] data = parts[1].Split(",");

                switch (type)
                {
                    case "SimpleGoal":
                        goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                        break;
                    case "EternalGoal":
                        goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                    case "ChecklistGoal":
                        goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]),
                                                    int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])));
                        break;
                }
            }

            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < goals.Count)
        {
            int pointsEarned = goals[choice].RecordEvent();
            totalPoints += pointsEarned;

            if (totalPoints % 1000 < pointsEarned) // hit a milestone
            {
                Console.WriteLine($"🎉 Congratulations! You reached {totalPoints} points! 🎉");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }
}
