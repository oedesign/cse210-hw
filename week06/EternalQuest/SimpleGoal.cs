using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Congratulations! You earned {_points} points!");
            return _points;
        }
        else
        {
            Console.WriteLine("This goal is already complete.");
            return 0;
        }
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetailsString()
    {
        string checkMark = _isComplete ? "[X]" : "[ ]";
        return $"{checkMark} {_name} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_name},{_description},{_points},{_isComplete}";
    }
}
