using System;
using System.Runtime.InteropServices;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0) 
            throw new ArgumentOutOfRangeException();
        int sum = 0;
        for (int i = 1; i < number; i++)
            if (number % i == 0) sum += i;
        if (sum < number) 
            return (Classification)2;
        else if (sum > number) 
            return (Classification)1;
        else 
            return (Classification)0;
    }
}
