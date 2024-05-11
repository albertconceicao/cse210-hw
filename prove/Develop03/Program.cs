using System;
class Program
{
    static void Main(string[] args)
    {

        Reference reference = new Reference("Alma", 37, 37,38);
        Scripture scripture2 = new Scripture(reference, "Counsel with the Lord in all thy doings, and he will direct thee for bgood; yea, when thou liest down at night lie down unto the Lord, that he may watch over you in your sleep; and when thou risest in the cmorning let thy heart be full of thanks unto God; and if ye do these things, ye shall be lifted up at the last day. And now, my son, I have somewhat to say concerning the thing which our fathers call a ball, or director—or our fathers called it aLiahona, which is, being interpreted, a compass; and the Lord prepared it.");

        Console.Clear();
        Console.WriteLine(scripture2.GetDisplayText());
        Console.WriteLine();
        
        string input = "";
        while (input != "quit")
        {
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            Console.WriteLine();
            input = Console.ReadLine();
            Console.Clear();
            scripture2.HideRandomWord(4);
            Console.WriteLine(scripture2.GetDisplayText());
            if(scripture2.IsCompletelyHidden() == true)
            {
                Console.WriteLine("Press enter to continue or type 'quit' to finish:");
                input = Console.ReadLine();
                Environment.Exit(0);
            };
            Console.WriteLine();
        }
    }
}