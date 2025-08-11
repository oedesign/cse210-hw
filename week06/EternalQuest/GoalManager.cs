using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 0;

    // Public read-only property
    public int Score => _score;

    // Adds points (can be negative), checks for level up and achievements
    public void AddPoints(int points)
    {
        _score += points;
        CheckLevelUp();
        CheckAchievements();
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal (penalty)");
        Console.Write("Choice: ");
        string typeChoice = Console.ReadLine()?.Trim();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points (for negative goal enter positive penalty): ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points. Aborting.");
            return;
        }

        switch (typeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Enter target completions: ");
                if (!int.TryParse(Console.ReadLine(), out int target)) { Console.WriteLine("Invalid target."); return; }
                Console.Write("Enter bonus points: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus)) { Console.WriteLine("Invalid bonus."); return; }
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, desc, points));
                break;
            default:
                Console.WriteLine("Invalid type choice.");
                break;
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("  (none)");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Create some first.");
            return;
        }

        ListGoals();
        Console.Write("Enter goal number to record: ");
        if (!int.TryParse(Console.ReadLine(), out int index))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        index -= 1;
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal g = _goals[index];
        int delta = g.RecordEvent();
        if (delta != 0)
        {
            AddPoints(delta);
            if (delta > 0)
                Console.WriteLine($"You earned {delta} points.");
            else
                Console.WriteLine($"You lost {-delta} points.");
        }
        else
        {
            Console.WriteLine("No points awarded for this action.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save (e.g. mygoals.txt): ");
        string filename = Console.ReadLine();
        try
        {
            using (var writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                writer.WriteLine(_level);
                foreach (var g in _goals)
                {
                    writer.WriteLine(g.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            var lines = File.ReadAllLines(filename);
            if (lines.Length < 2)
            {
                Console.WriteLine("File format invalid.");
                return;
            }

            _goals.Clear();
            _score = int.Parse(lines[0]);
            _level = int.Parse(lines[1]);

            for (int i = 2; i < lines.Length; i++)
            {
                string line = lines[i];
                var parts = line.Split('|');
                var type = parts[0];
                var data = parts[1].Split(',');

                switch (type)
                {
                    case "SimpleGoal":
                        // SimpleGoal|Name,Description,Points,IsComplete
                        _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                        break;
                    case "EternalGoal":
                        // EternalGoal|Name,Description,Points
                        _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                    case "ChecklistGoal":
                        // ChecklistGoal|Name,Description,Points,CurrentCount,TargetCount,BonusPoints
                        _goals.Add(new ChecklistGoal(
                            data[0],
                            data[1],
                            int.Parse(data[2]),
                            int.Parse(data[3]),
                            int.Parse(data[4]),
                            int.Parse(data[5])
                        ));
                        break;
                    case "NegativeGoal":
                        // NegativeGoal|Name,Description,PenaltyPoints
                        _goals.Add(new NegativeGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                    default:
                        Console.WriteLine($"Unknown goal type in file: {type}");
                        break;
                }
            }

            Console.WriteLine($"Loaded { _goals.Count } goals from {filename}. Score restored to {_score}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    private void CheckLevelUp()
    {
        int newLevel = _score / 1000;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"\n🎉 Level Up! You reached Level {_level}!\n");
        }
    }

    private void CheckAchievements()
    {
        if (_score >= 5000)
        {
            Console.WriteLine("🏆 Achievement: Goal Master (5000+ points)");
        }
        else if (_score >= 2000)
        {
            Console.WriteLine("🏅 Achievement: Goal Crusher (2000+ points)");
        }
    }
}
