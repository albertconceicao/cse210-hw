using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions","Section 7.3", "Problems 8-19");
        WritingAssignment writeAssignment = new WritingAssignment("Mary Waters", "European History","The Causes of World War II");
        Console.WriteLine(writeAssignment.GetSummary());
        Console.WriteLine(writeAssignment.GetWritingInformation());
    }
}
