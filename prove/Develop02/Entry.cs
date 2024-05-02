


public class Entry
{   

    public string _dateText;
    public string _promptText;
    public string _entryText;

    public string _feeling; 

    public void DisplayMessage() 
    {
        Console.WriteLine();
        Console.WriteLine($"Date: {_dateText} - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine($"Feeling at the moment: {_feeling}");
        Console.WriteLine();
    }
}