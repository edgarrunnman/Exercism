using System;
using System.Linq;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        if (input.Length == 0 ) return -1;
        int middleIndex = input.Length / 2;
        int indexRange = middleIndex;
        if (value == input[middleIndex]) return middleIndex;
        while (indexRange != 0)
        {
            indexRange = indexRange/ 2;
            if (value < input[middleIndex]) middleIndex -= indexRange + 1;
            else middleIndex += indexRange + 1;
            if (value == input[middleIndex]) return middleIndex;
        };
        return -1;
    }
}