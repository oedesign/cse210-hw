public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        return Points;
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return $"[ ] {Name} ({Description}) - Eternal Goal";
    }

    // Format: EternalGoal|Name|Description|Points
    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}";
    }
}
