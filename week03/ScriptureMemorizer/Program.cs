/*
    W03 Project: Scripture Memorizer Program

    Enhancement to exceed requirements:
    - Instead of using only one hardcoded scripture, this program loads multiple scriptures 
      from a text file named "scriptures.txt".
    - Each time the program runs, it randomly selects one scripture from the file.
    - This helps users practice different verses each session and supports an expandable scripture library.

    File format (scriptures.txt): 
    Book|Chapter|StartVerse|[EndVerse]|ScriptureText
    Example:
    John|3|16|For God so loved the world...
    Proverbs|3|5|6|Trust in the Lord...
*/

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "scriptures.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Missing 'scriptures.txt'. Please add it and try again.");
            return;
        }

        List<Scripture> scriptureLibrary = LoadScripturesFromFile(filePath);
        if (scriptureLibrary.Count == 0)
        {
            Console.WriteLine("No scriptures found in the file.");
            return;
        }

        var random = new Random();
        Scripture scripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        // Main memorization loop
        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Well done!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine();
                if (string.Equals(input.Trim(), "quit", StringComparison.OrdinalIgnoreCase))
                    break;
    
                scripture.HideRandomWords();
            }
        }
    
        static List<Scripture> LoadScripturesFromFile(string filePath)
        {
            var scriptures = new List<Scripture>();
            foreach (var line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
    
                var parts = line.Split('|');
                try
                {
                    if (parts.Length == 5) // With end verse
                    {
                        var reference = new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
                        scriptures.Add(new Scripture(reference, parts[4]));
                    }
                    else if (parts.Length == 4) // Single verse
                    {
                        var reference = new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]));
                        scriptures.Add(new Scripture(reference, parts[3]));
                    }
                }
                catch
                {
                    Console.WriteLine($"Error loading line: {line}");
                }
            }
            return scriptures;
        }
    }
