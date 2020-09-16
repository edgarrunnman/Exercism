using System;
using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> oldSystem)
    {
        Dictionary<string, int> newSystem = new Dictionary<string, int>();
        foreach (var item in oldSystem)
            for (int i = 0; i < item.Value.Length; i++)
                newSystem.Add(item.Value[i].ToLower(), item.Key);
        return newSystem;
    }
}