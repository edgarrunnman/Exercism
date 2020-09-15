using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        string output = "";
        for (int i = 1; i <= input.Length; i++) output += input[input.Length - i];
        return output;
    }
}