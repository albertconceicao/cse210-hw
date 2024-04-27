using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userFullName = PromptUserName();
        int userFavoriteNumber = PromptUserNumber();
        int userFavoriteSquareNumber = SquareNumber(userFavoriteNumber);

        DisplayResults(userFullName, userFavoriteSquareNumber);
        static void DisplayWelcome() 
        {
            Console.WriteLine("Welcome to the program!");   
        }
        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string fullName = Console.ReadLine();

            return fullName;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int favoriteNumber = int.Parse(Console.ReadLine());

            return favoriteNumber;
        }

        static int SquareNumber(int favoriteNumber)
        {
            int favoriteSquare = favoriteNumber * favoriteNumber;

            return favoriteSquare;
        }

        static void DisplayResults(string fullName, int userFavoriteSquareNumber)
        {
            Console.WriteLine($"{fullName}, the square of your number is {userFavoriteSquareNumber}.");
        }

    }
}