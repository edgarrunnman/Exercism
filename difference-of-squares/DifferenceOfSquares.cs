using System;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        string maxString = max.ToString();
        int sum = 0;
        for (int i = 1; i <= max; i++) sum += i;
        return (int)Math.Pow((double)sum, 2.0);
    }

    public static int CalculateSumOfSquares(int max)
    {
        string maxString = max.ToString();
        int sum = 0;
        for (int i = 1; i <= max; i++) sum += (int)Math.Pow((double)i, 2.0);
        return sum;
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }

}