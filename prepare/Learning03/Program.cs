using System;
public class Fractional
{
    private int _top;
    private int _bottom;
    
    public Fractional()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fractional(int wholeNumber)
    { 
        _top = wholeNumber;
        _bottom = 1;
    }

    public string GetFractionalString()
    {
        string text = $"{_top}/{_bottom}";
        return text;
    }

        public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}
    