public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = ["Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"];

    public ListingActivity(string name, string description, int count): base(name, description)
    {
        _count = count;
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        DisplayPrompt();
        GetListFromUser();
        DisplayEndingMessage();
    }

    public void DisplayPrompt()
    {
        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine();
        GetRandomPrompt();
        Console.WriteLine();
        Console.Write($"You may begin in: ");
        ShowCountDown(5);
    }
    public void GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        Console.WriteLine(_prompts[index]);
    }

    public List<string> GetListFromUser()
    {
        Console.Clear();
        List<string> userInputList = new List<string>();
        int duration = _duration;
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                userInputList.Add(input);
            }
        }
        Console.WriteLine($"You listed {userInputList.Count} items!");

        return userInputList;
    }
}