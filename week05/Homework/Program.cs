using System;

class Program
{
    static void Main()
    {
        // Base class test
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment.GetSummary());

        Console.WriteLine();

        // Math assignment test
        MathAssignment math = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());

        Console.WriteLine();

        // Writing assignment test
        WritingAssignment writing = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
    }
}
