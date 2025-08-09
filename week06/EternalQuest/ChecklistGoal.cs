using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int currentCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = currentCount;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        int earnedPoints = _points;
        if (_currentCount == _targetCount)
        {
            earnedPoints += _bonusPoints;
            Console.WriteLine($"Bonus! You completed this goal and earned {_bonusPoints} extra points!");
        }
        Console.WriteLine($"You earned {_points} points! Progress: {_currentCount}/{_targetCount}");
        return earnedPoints;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetDetailsString()
    {
        string checkMark = IsComplete() ? "[X]" : "[ ]";
        return $"{checkMark} {_name} ({_description}) -- Completed {_currentCount}/{_targetCount} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name},{_description},{_points},{_targetCount},{_currentCount},{_bonusPoints}";
    }
}
