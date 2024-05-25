public class SimpleGoal: Goal
{
    private Boolean _isComplete;

    public SimpleGoal(string shortName, string description, string points) :base(shortName, description, points)
    {
    }

    public override void RecordEvent()
    {
        
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{base.GetStringRepresentation()},{_isComplete}";
    }
}