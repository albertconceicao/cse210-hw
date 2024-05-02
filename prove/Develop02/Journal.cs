
using System.IO;
public class Journal
{

    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayMessage();
        }
    }
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._dateText},{entry._promptText},{entry._entryText},{entry._feeling}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {   
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string entryString in lines)
        {

            string[] parts = entryString.Split(",");

            string loadedDate = parts[0];
            string loadedPrompt = parts[1];
            string loadedEntryText = parts[2];
            string loadedFeeling = parts[3];

            Entry entry = new Entry(); 
            entry._dateText = loadedDate;
            entry._promptText = loadedPrompt;
            entry._entryText = loadedEntryText;
            entry._feeling = loadedFeeling;
            _entries.Add(entry);
        }
    }
}