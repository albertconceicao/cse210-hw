using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);

        int userGuess = 0;
        while (userGuess != number)
        {
            Console.Write("What is your guess? ");
            userGuess = int.Parse(Console.ReadLine());

            if (number > userGuess)
            {
                Console.WriteLine("Higher");
            }
            else if (number < userGuess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}