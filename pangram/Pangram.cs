using System;
using System.Collections.Generic;
using System.Linq;

public static class Pangram
{    
    public static bool IsPangram(string input)
    {
        List<char> characterCollection = new List<char>();
        foreach (var value in Enumerable.Range((int)'a', ((int)'z' - (int)'a')))
            characterCollection.Add(Convert.ToChar(value));
        foreach (var character in input.ToLower()) 
            try { characterCollection.Remove(character); } catch { }
        if (characterCollection.Count == 0) 
            return true;
        else 
            return false;
    }
}
