public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {
        
    }

    public void Run()
    {
        Console.Clear();
        DisplayStartingMessage();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.Clear();
        int totalDuration = _duration;
        int cycleTime = 4 + 6; // Total time for one cycle of breath in and breath out
        int fullCycles = totalDuration / cycleTime;
        int remainingTime = totalDuration % cycleTime;

        for (int i = 0; i < fullCycles; i++)
        {
            // Breath in for 4 seconds
            Console.Write("Breath in... ");
            ShowCountDown(4);

            // Breath out for 6 seconds
            Console.Write("Now breath out... ");
            ShowCountDown(6);
        }

        // Handle remaining time after full cycles
        if (remainingTime > 0)
        {
            if (remainingTime <= 4)
            {
                Console.Write("Breath in... ");
                ShowCountDown(remainingTime);
            }
            else
            {
                Console.Write("Breath in... ");
                ShowCountDown(4);

                Console.Write("Now breath out... ");
                ShowCountDown(remainingTime - 4);
            }
        }
        DisplayEndingMessage();
    }
}