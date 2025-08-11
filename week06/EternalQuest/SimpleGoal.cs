public class SimpleGoal : Goal
{
    private bool _isComplete;

    // Normal constructor
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Constructor used when loading with known state
    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    // Returns the points awarded (0 if already complete)
    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return Points;
        }
        return 0;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetailsString()
    {
        return $"[ {(IsComplete() ? "X" : " ")} ] {Name} ({Description})";
    }

    // Format: SimpleGoal|Name|Description|Points|IsComplete
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{Name}|{Description}|{Points}|{_isComplete}";
    }
}
