using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        Dictionary<char, int> cntr = new Dictionary<char, int>()
        {
            { '(', 0 },
            { '[', 0 },
            { '{', 0 }
        };
        char? firstBracketType = null;
        char? secondBracketType = null;
        char? thirdBracketType = null;
        for (int i = 0; i < input.Length; i++)
        {
            if (firstBracketType == null) 
                firstBracketType = input[i];

            else if (secondBracketType == null && firstBracketType != input[i]) 
                secondBracketType = input[i];

            else if (thirdBracketType == null && firstBracketType != input[i] && secondBracketType != input[i]) 
                thirdBracketType = input[i];

            switch (input[i])
            {
                case '(':
                    cntr['('] += 1;
                    break;
                case '[':
                    cntr['['] += 1;
                    break;
                case '{':
                    cntr['{'] += 1;
                    break;
                case ')':
                    cntr['('] -= 1;
                    break;
                case ']':
                    cntr['['] -= 1;
                    break;
                case '}':
                    cntr['{'] -= 1;
                    break;
            }

            if (cntr['('] < 0 || cntr['['] < 0 || cntr['{'] < 0)
                return false;
            try
            {
                if (cntr[(char)firstBracketType] < cntr[(char)secondBracketType]) 
                    return false;
            }
            catch { }
            try
            {
                if (cntr[(char)firstBracketType] < cntr[(char)thirdBracketType]
                    && cntr[(char)secondBracketType] < cntr[(char)thirdBracketType]) 
                    return false;
            }
            catch { }
        }
        if (cntr['('] == 0 && cntr['['] == 0 && cntr['{'] == 0) return true;
        return false;
    }
}