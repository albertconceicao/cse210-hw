public class SimpleGoal: Goal
{
    private Boolean _isComplete;

    public SimpleGoal(string shortName, string description, string points, Boolean isComplete) :base(shortName, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        if (_isComplete == true)
        {
            return true;
        } else{
            return false;
        }
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{base.GetStringRepresentation()},{_isComplete}";
    }
}