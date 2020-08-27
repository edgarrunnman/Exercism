using System;

public static class ResistorColor
{
    public static int ColorCode(string color)
    {
        string[] colors = Colors();
        int index = 0;
        int CodeValueToReturn = 100;
        foreach (string colorCodeText in colors)
        {
            if (colorCodeText == color) CodeValueToReturn = index;
            index++;
        }
        return CodeValueToReturn;
    }

    public static string[] Colors()
    {
        string[] mystring = { "Black", "Brown", "Red", "Orange", "Yellow", "Green", "Blue", "Violet", "Grey", "White" };
        return mystring;
    }
    static void Main(string[] args)
    {
        int Code = ColorCode("black");
        Console.WriteLine(Code);
    }
}