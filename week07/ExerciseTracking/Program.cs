using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>()
        {
            new Running(new DateTime(2025, 8, 14), 30, 3.0),
            new Cycling(new DateTime(2025, 8, 13), 45, 15.0),
            new Swimming(new DateTime(2025, 8, 12), 25, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
