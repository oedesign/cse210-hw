using System;

// ✅ Exceeds Core Requirements:
// - Added mood tracking for each journal entry
// - Saved/loaded mood with entries using custom format
// - Mood is shown when displaying entries

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    Console.Write("Your mood today (e.g., Happy, Sad, Anxious, Excited): ");
                    string mood = Console.ReadLine();
                    journal.AddEntry(new Entry(prompt, response, mood));
                    break;

                case "2":
                    Console.WriteLine("\n📔 Journal Entries:\n");
                    journal.DisplayJournal();
                    break;

                case "3":
                    Console.Write("Enter filename to save to: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;

                case "4":
                    Console.Write("Enter filename to load from: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;

                case "5":
                    Console.WriteLine("Goodbye! 👋");
                    running = false;
                    break;

                default:
                    Console.WriteLine("❌ Invalid option. Please try again.");
                    break;
            }
        }
    }
}
