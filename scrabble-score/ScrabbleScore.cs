using System;

public static class ScrabbleScore
{
    private enum letterValues : int
    {
        AEIOULNRST = 1,
        DG = 2,
        BCMP = 3,
        FHVWY = 4,
        K = 5,
        JX = 8,
        QZ = 10
}
    public static int Score(string input)
    {
        int score = 0;
        input = input.ToUpper();
        foreach (var inputChar in input)
            foreach (var item in Enum.GetValues(typeof(letterValues)))
                foreach (var scoreChar in item.ToString())
                    if (inputChar == scoreChar) score += (int)item;
        return score;

    }
    
}
