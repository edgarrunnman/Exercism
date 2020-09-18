using System;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        string[] returnArray = new string[subjects.Length];
        string[] text = new string[]
        {
            "For want of a ",
            " the ",
            " was lost.",
            "And all for the want of a ",
            "."
        };
        for (int i = 0; i < subjects.Length; i++)
        {
            if ((i + 1) < subjects.Length)
                returnArray[i] = text[0] + subjects[i] + text[1] + subjects[i + 1] + text[2];
            else returnArray[i] = text[3] + subjects[0] + text[4];
        }
        return returnArray;

    }
}