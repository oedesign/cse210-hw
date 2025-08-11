public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    // Constructor used when loading to restore counts
    public ChecklistGoal(string name, string description, int points, int currentCount, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = currentCount;
    }

    // Returns the points awarded (including bonus if completed by this event)
    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0; // already complete, no more points
        }

        _currentCount++;
        if (IsComplete())
        {
            return Points + _bonusPoints;
        }
        return Points;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetDetailsString()
    {
        return $"[ {(IsComplete() ? "X" : " ")} ] {Name} ({Description}) -- {_currentCount}/{_targetCount}";
    }

    // Format: ChecklistGoal|Name|Description|Points|CurrentCount|TargetCount|BonusPoints
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_currentCount}|{_targetCount}|{_bonusPoints}";
    }
}
