public abstract class Goal{
    private string _shortName;
    private string _description;
    private string _points;

    public Goal(string shortName, string description, string points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();

    public  abstract Boolean IsComplete();

    public virtual string GetDetailString()
    {
        return $"{_shortName} ({_description})";
    }

    public virtual string GetStringRepresentation()
    {
        return $"{_shortName},{_description},{_points}";
    }
    public string GetShortName()
    {
        return _shortName;
    }

}