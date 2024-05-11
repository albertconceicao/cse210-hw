public class Word
{
    private string _text;
    private Boolean _isHidden;

    public Word(string text)
    {
        _text = text;
    }
    public void Hide()
    {
        foreach(char character in _text)
        {
            if (character != ' ' || character != '_')
            {
                _text = _text.Replace(character, '_');
            }
        
        }
    }
    public void Show()
    {   
        _text = _text.Replace('_', ' ');
    }
    public Boolean IsHidden()
    {
        if(_text.Contains("_") || _text.Length == 0)
        {
            _isHidden = true;
        }
        return _isHidden;
    }
    public string GetDisplayText()
    {
        return _text + " ";
    }

}