using System;

public class GoalManager
{
    List<Goal> _goals = new List<Goal>();
    private int _score;
    public GoalManager()
    {

    }

    public void Start()
    {
        int userPrompt = 0;
            while (userPrompt != 6)
            {
                DisplayPlayerInfo();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("   1. Create New Goal");
                Console.WriteLine("   2. List Goals");
                Console.WriteLine("   3. Save Goals");
                Console.WriteLine("   4. Load Goals");
                Console.WriteLine("   5. Record Event");
                Console.WriteLine("   6. Quit");
                Console.WriteLine("Select a choice from the menu: ");
                
                if (!int.TryParse(Console.ReadLine(), out userPrompt) || userPrompt < 1 || userPrompt > 6)
                {
                    Console.WriteLine("Invalid option. Please choose a number between 1 and 6.");
                }
                else
                {
                    switch (userPrompt)
                    {
                        case 1:
                            CreateGoal();
                            break;
                        case 2:
                            ListGoalNames();
                            break;
                        case 3:
                            SaveGoals();
                            break;
                        case 4:
                            LoadGoals();
                            break;
                        case 5:
                            RecordEvent();
                            break;
                        default:
                            break;
                    }
                }
            }
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {_score} points");
        Console.WriteLine();
    }
    public void ListGoalNames()
    {
        Console.WriteLine("The goals are: ");
        int index = 0;
        foreach (Goal goal in _goals)
        {
            index++;
            Console.WriteLine($"{index}. {goal.GetDetailString()}");
        }
    }
    public void ListGoalDetails()
    {
        Console.WriteLine("List Goal Details");
    }
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");

        Console.WriteLine("   1. Simple Goal");
        Console.WriteLine("   2. Eternal Goal");
        Console.WriteLine("   3. Checklist Goal");

        Console.WriteLine("Which type of goal would you like to create? ");

        int goalType = int.Parse(Console.ReadLine());
        string shortName = "";
        string shortDescription = "";
        string points = "";

        switch (goalType)
        {
            case 1:
                Console.WriteLine("What is the name of your goal? ");
                shortName = Console.ReadLine();
                Console.WriteLine("What is a short descripton of it? ");
                shortDescription = Console.ReadLine();
                Console.WriteLine("What is the amount of points associated with this goal? ");
                points = Console.ReadLine();
                SimpleGoal simpleGoal = new SimpleGoal(shortName, shortDescription, points);
                _goals.Add(simpleGoal);
                break;
            case 2:
                Console.WriteLine("What is the name of your goal? ");
                shortName = Console.ReadLine();
                Console.WriteLine("What is a short descripton of it? ");
                shortDescription = Console.ReadLine();
                Console.WriteLine("What is the amount of points associated with this goal? ");
                points = Console.ReadLine();
                EternalGoal eternalGoal = new EternalGoal(shortName, shortDescription, points);
                _goals.Add(eternalGoal);
                break;
            case 3:
                Console.WriteLine("What is the name of your goal? ");
                shortName = Console.ReadLine();
                Console.WriteLine("What is a short descripton of it? ");
                shortDescription = Console.ReadLine();
                Console.WriteLine("What is the amount of points associated with this goal? ");
                points = Console.ReadLine();
                Console.WriteLine("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                ChecklistGoal checklistGoal = new ChecklistGoal(shortName, shortDescription, points, target, bonus);
                _goals.Add(checklistGoal);
                break;
        }
    }
    public void RecordEvent()
    {
        Console.WriteLine("Record Event");
    }

    public void SaveGoals()
    {
        Console.WriteLine("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine($"{goal.GetStringRepresentation()}");
            }
        }
    }

    public void LoadGoals()
    {
        Console.WriteLine("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string GoalString in lines)
        {

            string[] parts = GoalString.Split(",");

            Type LoadedType = Type.GetType(parts[0]);
            string loadedPrompt = parts[1];
            string loadedGoalText = parts[2];
            string loadedFeeling = parts[3];

            loadedType goal = new loadedType(); 
            goal._dateText = loadedDate;
            goal._promptText = loadedPrompt;
            goal._GoalText = loadedGoalText;
            goal._feeling = loadedFeeling;
            _goals.Add(goal);
        }
    }

}