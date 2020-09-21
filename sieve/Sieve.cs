using System;
using System.Collections.Generic;
using System.Linq;

public class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2) throw new ArgumentOutOfRangeException();
        HashSet<int> numbers = new HashSet<int>();
        for (int i = 2; i <= limit; i++)
            numbers.Add(i);
        for (int i = 2; i <= limit; i++)
            for (int y = 2; y <= limit; y++)
            {
                int nextNumber = i * y;
                if (nextNumber <= limit)
                    numbers.Remove(nextNumber);
            }
        return numbers.ToArray();
    }
}