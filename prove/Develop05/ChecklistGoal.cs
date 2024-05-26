public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, string points, int target, int bonus, int currentAmount) : base(shortName, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = currentAmount;
    }

    public override void RecordEvent()
    {   
        
        _amountCompleted++;
        
    }
    public override bool IsComplete()
    {
        if (_amountCompleted >= _target)
        {
            return true;
        } else
        {
            return false;
        }
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