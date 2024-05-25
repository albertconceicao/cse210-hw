public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, string points, int target, int bonus) : base(shortName, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        
    }
    public override bool IsComplete()
    {
        return false;
    }
    public override string GetDetailString()
    {
        return base.GetDetailString() + $" -- Currently completed: {_amountCompleted}/{_target}";
    }
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{base.GetStringRepresentation()},{_bonus},{_target},{_amountCompleted}";
    }
}