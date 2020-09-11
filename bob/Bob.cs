using System;

public static class Bob
{
    private static bool _isQuestion;
    private static bool _isYell;
    private static bool _containsLowLevelChar;
    private static bool _isEmpty;


    public static string Response(string statement)
    {
        statement = statement.Replace("\n", String.Empty);
        statement = statement.Replace("\r", String.Empty);
        statement = statement.Replace("\t", String.Empty);
        statement = statement.Replace(" ", String.Empty);
        _isQuestion = statement.EndsWith("?");
        _isYell = false;
        _containsLowLevelChar = false;
        foreach (char character in statement)
        {
            if (char.GetUnicodeCategory(character) != char.GetUnicodeCategory('a') && char.GetUnicodeCategory(character) != char.GetUnicodeCategory('A'))
            {
                continue;
            }
            else if (char.GetUnicodeCategory(character) == char.GetUnicodeCategory('a'))
            {
                _containsLowLevelChar = true;
                _isYell = false;
            }
            else if (char.GetUnicodeCategory(character) == char.GetUnicodeCategory('A'))
            {
                _isYell = true;
            }
        }
        _isEmpty = (statement.Length == 0) ? true : false;

        if (_isQuestion && _isYell && !_containsLowLevelChar) return "Calm down, I know what I'm doing!";
        else if (_isQuestion && _containsLowLevelChar) return "Sure.";
        else if (_isQuestion) return "Sure.";
        else if (_isYell && !_containsLowLevelChar) return "Whoa, chill out!";
        else if (_isEmpty) return "Fine. Be that way!";
        else return "Whatever.";
    }


}