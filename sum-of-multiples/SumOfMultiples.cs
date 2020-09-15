using System;
using System.Collections.Generic;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        int sum = 0;
        List<int> multiplesList = new List<int>();
        for (int i = 0; i < max; i++)
        {
            foreach(int n in multiples)
            {
                if (n != 0)
                {
                    if ((i % n) == 0 && !multiplesList.Contains(i))
                    {
                        multiplesList.Add(i);
                        sum += i;
                    }
                }
            }
        }
        return sum;
    }
}