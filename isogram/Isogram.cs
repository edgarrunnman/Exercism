using System;
using System.Collections.Generic;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        word = word.ToLower();
        Dictionary<char, int> letterCounter = new Dictionary<char, int>();
        for (int i = (int)'a'; i <= (int)'z'; i++)
            letterCounter.Add((char)i, 0);
        foreach(char letter in word)
            if (letterCounter.TryGetValue(letter, out int count))
            {
                letterCounter[letter] = ++count;
                if (count > 1) return false;
            }
        return true;
    }
}
