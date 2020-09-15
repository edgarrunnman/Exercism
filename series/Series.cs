using System;
using System.Collections.Generic;

using Xunit.Sdk;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if ((sliceLength > numbers.Length) || sliceLength <= 0) throw new ArgumentException();
        List<string> sliceList = new List<string>();
        for (int i = 0; i <= numbers.Length; i++)
        {
            int sliceIndex = i;
            if (sliceLength + i <= numbers.Length)
            {
                string slice = "";
                while (sliceIndex < sliceLength + i)
                {
                    slice += numbers[sliceIndex];
                    sliceIndex++;
                }
                sliceList.Add(slice);
            }
        }
        if (sliceList.Count == 0) throw new ArgumentException();
        return sliceList.ToArray();
    }
}