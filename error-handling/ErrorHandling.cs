using System;
using System.Data;
using System.Diagnostics;
using System.Threading;

public static class ErrorHandling
{
    public static void HandleErrorByThrowingException()
    {
        throw new System.Exception();
    }

    public static int? HandleErrorByReturningNullableType(string input)
    {
        int? returnValue = null;
        try { returnValue = Convert.ToInt32(input); }
        catch { }
        return returnValue;
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        try { result = Convert.ToInt32(input); }
        catch 
        {
            result = 0;
            return false; 
        }
        return true;
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        try { disposableObject.Dispose(); }
        catch { }
        throw new System.Exception();
    }
}
