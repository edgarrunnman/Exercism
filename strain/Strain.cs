using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.ExceptionServices;

public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        HashSet<T> returnObject = new HashSet<T>();
        foreach (var x in collection)
        {
            if (predicate(x)) returnObject.Add(x);
        }
        return returnObject;
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        HashSet<T> returnObject = new HashSet<T>();
        foreach (var x in collection)
        {
            if (!predicate(x)) returnObject.Add(x);
        }
        return returnObject;
    }
}