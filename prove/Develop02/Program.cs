using System;

class Program
{
    static void Main(string[] args)
    {

        AskUser();
        static void AskUser()
        {
            Journal journal = new Journal();
            PromptGenerator prompt = new PromptGenerator();
            int userPrompt = 0;
            while (userPrompt != 5)
            {
                Console.WriteLine("Welcome to the Journal Program!");
                Console.WriteLine("Please select one of the following choices:");
                Console.WriteLine("1. Write");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Quit");
                Console.WriteLine("What would you like to do? ");
                
                if (!int.TryParse(Console.ReadLine(), out userPrompt) || userPrompt < 1 || userPrompt > 5)
                {
                    Console.WriteLine("Invalid option. Please choose a number between 1 and 5.");
                }
                else
                {
                    switch (userPrompt)
                    {
                        case 1:
                            string randomPrompt = prompt.GetRandomPrompt();
                            Console.WriteLine(randomPrompt);
                            DateTime theCurrentTime = DateTime.Now;
                            string dateText = theCurrentTime.ToShortDateString();
                            string entryText = Console.ReadLine();
                            Console.WriteLine("How are you feeling now? ");
                            string feeling = Console.ReadLine();
                            Entry entry = new Entry();
                            entry._dateText = dateText;
                            entry._promptText = randomPrompt;
                            entry._entryText = entryText;
                            entry._feeling = feeling;
                            journal.AddEntry(entry);
                            break;
                        case 2:
                            journal.DisplayAll();
                            break;
                        case 3:
                            Console.WriteLine("What is the filename? ");
                            string saveFilename = Console.ReadLine();
                            journal.LoadFromFile(saveFilename);
                            break;
                        case 4:
                            Console.WriteLine("What is the filename? ");
                            string loadFilename = Console.ReadLine();
                            journal.SaveToFile(loadFilename);
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine("Congratulations for feeding your journal. Have a great day!");
         }
    }
}