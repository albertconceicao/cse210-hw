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
                Console.Write("Select a choice from the menu: ");
                
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
                            ListGoalDetails();
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
        
        int index = 0;

        foreach (Goal goal in _goals)
        {
            index++;
            string[] goalInfo = goal.GetStringRepresentation().Split(":");
            string[] parameters = goalInfo[1].Split(",");
            string goalName = parameters[1];
            
            Console.WriteLine($"{index}. {goalName}");

        }
        Console.Write("Which goal did you completed? ");
        int goalCompleted;
        bool isValid = int.TryParse(Console.ReadLine(), out goalCompleted);
        if (isValid && goalCompleted > 0 && goalCompleted <= _goals.Count)
        {
            Goal selectedGoal = _goals[goalCompleted - 1]; // Índices de array começam em 0, ajustar para 1-base

            selectedGoal.RecordEvent(); 
            string[] goalInfo = selectedGoal.GetStringRepresentation().Split(":");
            string goalType = goalInfo[0];
            string[] parameters = goalInfo[1].Split(",");
            int points = int.Parse(parameters[2]);
            
            if (goalType == "ChecklistGoal")
            {
                int target = int.Parse(parameters[4]);
                int currentAmount = int.Parse(parameters[5]);
                int bonus = int.Parse(parameters[3]);
                if (currentAmount == target)
                {
                    Console.WriteLine("Congratulations you finished this goal");
                    int total = points += bonus;
                    Console.WriteLine($"You have earned {total} points.");
                    _score += total;
                } else {
                    Console.WriteLine($"Congratulations! You have earned {points} points");
                    _score += points;
                }
            } else 
            {
                Console.WriteLine($"Congratulations! You have earned {points} points");
                _score += points;
            
            }
            Console.WriteLine($"You now have {_score} points.");
            
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }

        
    }
    public void ListGoalDetails()
    {
        
        Console.WriteLine("The goals are: ");
        int index = 0;
        foreach (Goal goal in _goals)
        {
            index++;
            if(goal.IsComplete() == true)
            {
                Console.WriteLine($"{index}. [X] {goal.GetDetailString()}");
            } else 
            {
                Console.WriteLine($"{index}. [ ] {goal.GetDetailString()}");
            }
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");

        Console.WriteLine("   1. Simple Goal");
        Console.WriteLine("   2. Eternal Goal");
        Console.WriteLine("   3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");

        int goalType = int.Parse(Console.ReadLine());
        string shortName = "";
        string shortDescription = "";
        string points = "";

        switch (goalType)
        {
            case 1:
                Console.Write("What is the name of your goal? ");
                shortName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is a short descripton of it? ");
                shortDescription = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is the amount of points associated with this goal? ");
                points = Console.ReadLine();
                SimpleGoal simpleGoal = new SimpleGoal(shortName, shortDescription, points, false);
                _goals.Add(simpleGoal);
                break;
            case 2:
                Console.Write("What is the name of your goal? ");
                shortName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is a short descripton of it? ");
                shortDescription = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is the amount of points associated with this goal? ");
                points = Console.ReadLine();
                EternalGoal eternalGoal = new EternalGoal(shortName, shortDescription, points);
                _goals.Add(eternalGoal);
                break;
            case 3:
                Console.Write("What is the name of your goal? ");
                shortName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is a short descripton of it? ");
                shortDescription = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is the amount of points associated with this goal? ");
                points = Console.ReadLine();
                Console.WriteLine();
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                Console.WriteLine();
                ChecklistGoal checklistGoal = new ChecklistGoal(shortName, shortDescription, points, target, bonus, 0);
                _goals.Add(checklistGoal);
                break;
        }
    }
    public void RecordEvent()
    {
        ListGoalNames();
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

        if (lines.Length > 0)
        {
    
            _score = int.Parse(lines[0]);
            

            for (int i = 1; i < lines.Length; i++)
            {
                string GoalString = lines[i];
                string[] parts = GoalString.Split(":");

                string typeName = parts[0];
                string[] parameters = parts[1].Split(',');


                    try
                    {
                        if (typeName == "SimpleGoal" && parameters.Length >= 3)
                        {
                            SimpleGoal simpleGoal = new SimpleGoal(parameters[0], parameters[1], parameters[2], Boolean.Parse(parameters[3]));
                            _goals.Add(simpleGoal);
                        }
                        else if (typeName == "EternalGoal" && parameters.Length >= 3)
                        {
                            EternalGoal eternalGoal = new EternalGoal(parameters[0], parameters[1], parameters[2]);
                            _goals.Add(eternalGoal);
                        }
                        else if (typeName == "ChecklistGoal" && parameters.Length >= 5)
                        {
                            ChecklistGoal checklistGoal = new ChecklistGoal(parameters[0], parameters[1], parameters[2], int.Parse(parameters[4]), int.Parse(parameters[3]), int.Parse(parameters[5]));
                            _goals.Add(checklistGoal);
                        }
                        else
                        {
                            Console.WriteLine("Invalid format or insufficient parameters.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error creating goal: {ex.Message}");
                    }
            }
        }
        else
        {
            Console.WriteLine("The file is empty or does not contain enough lines.");
        }
    }


}