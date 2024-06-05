using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 6, 5), 30, 3.0),
            new Cycling(new DateTime(2024, 6, 5), 30, 20.0),
            new Swimming(new DateTime(2024, 6, 5), 30, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}