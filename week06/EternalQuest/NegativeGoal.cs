// Creativity bonus: NegativeGoal subtracts points when recorded (bad habit tracker)
public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int penaltyPoints)
        : base(name, description, -penaltyPoints) { }

    public override int RecordEvent()
    {
        // Points is negative
        return Points;
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        // Show penalty as positive number for readability
        return $"[ ] {Name} ({Description}) - Negative Goal (penalty {-Points} pts)";
    }

    // Format: NegativeGoal|Name|Description|PenaltyPoints
    public override string GetStringRepresentation()
    {
        // store penalty as positive value
        return $"NegativeGoal|{Name}|{Description}|{-Points}";
    }
}
