public abstract class Goal
{
    // Encapsulated fields (private)
    private string _name;
    private string _description;
    private int _points;

    // Public properties (read-only)
    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    // Base constructor
    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // RecordEvent should apply the goal's effect and return points delta (could be negative)
    public abstract int RecordEvent();

    // Whether the goal is considered complete
    public abstract bool IsComplete();

    // For display in the list of goals
    public abstract string GetDetailsString();

    // For saving/loading to/from file (string representation with state)
    public abstract string GetStringRepresentation();
}
