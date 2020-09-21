using System;

public static class SecretHandshake
{
    private static (int code, string messege)[] _codeTable = new (int code, string messege)[]
    {
        (1, "wink" ),
        (10, "double blink"),
        (100, "close your eyes"),
        (1000, "jump")
    };
    public static string[] Commands(int commandValue)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}
