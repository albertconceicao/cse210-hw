public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }
public void HideRandomWord(int numberToHide)
{
    Random random = new Random();
    int hiddenCount = 0;

    
        if (numberToHide > _words.Count(word => !word.IsHidden()))
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden())
                {
                    word.Hide();
                }
            }
            return;
        }

        while (hiddenCount < numberToHide)
        {
            int randomIndex = random.Next(0, _words.Count);
            if (!_words[randomIndex].IsHidden() && !_words[randomIndex].GetDisplayText().Contains("_"))
            {
                _words[randomIndex].Hide();
                hiddenCount++;
            }
        }


}
    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText();
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText(); 
        }
        return displayText;
    }
    public bool IsCompletelyHidden()
    {
        bool allHidden = true;
        foreach (Word word in _words)
        {
            if (!word.GetDisplayText().Contains("_"))
            {
                allHidden = false;
                break;
            }
        }
        return allHidden;
    }
}