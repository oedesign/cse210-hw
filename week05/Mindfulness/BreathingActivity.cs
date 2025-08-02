using System;
using System.Threading;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
        : base("Breathing Activity",
              "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            CountdownTimer(4);
            Console.Write("\nNow breathe out... ");
            CountdownTimer(6);
        }

        DisplayEndingMessage();
    }
}
