using System;

class Program
{
    static void Main(string[] args)
    {
            int userPrompt = 0;
            int numberOfActivities = 0;
            while (userPrompt != 4)
            {
                Console.WriteLine("Menu Options:");
                Console.WriteLine("   1. Start breathing activity");
                Console.WriteLine("   2. Start reflecting activity");
                Console.WriteLine("   3. Start listing activity");
                Console.WriteLine("   4. Quit");
                Console.WriteLine("Select a choice from the menu: ");
                
                if (!int.TryParse(Console.ReadLine(), out userPrompt) || userPrompt < 1 || userPrompt > 5)
                {
                    Console.WriteLine("Invalid option. Please choose a number between 1 and 4.");
                }
                else
                {
                    switch (userPrompt)
                    {
                        case 1:
                            BreathingActivity breathingActivity = new BreathingActivity("Breathing Activity. ", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing. ");
                            breathingActivity.Run();
                            numberOfActivities++;
                            break;
                        case 2:
                            ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting Activity. ", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                            reflectingActivity.Run();
                            numberOfActivities++;
                            break;
                        case 3:
                            ListingActivity listingActivity = new ListingActivity("Listing Activity. ", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 0);
                            listingActivity.Run();
                            numberOfActivities++;
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine($"Thanks for being with us in this activity, you performed {numberOfActivities} activities. See you soon!");
    }
}