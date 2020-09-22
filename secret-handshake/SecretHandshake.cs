using System;
using System.Collections.Generic;
using System.Linq;

public static class SecretHandshake
{
    private static (int code, string messege)[] _codeTable = new (int code, string messege)[]
    {
        (0b00001, "wink" ),
        (0b00010, "double blink"),
        (0b00100, "close your eyes"),
        (0b01000, "jump")
    };
    //public static string[] Commands(int commandValue)
    //{
    //    List<string> returnList = new List<string>();
    //    foreach (var item in _codeTable)
    //        if ((item.code & commandValue) == item.code) returnList.Add(item.messege);
    //    if ((16 & commandValue) == 16) returnList.Reverse();
    //    return returnList.ToArray();
    //}
    public static string[] Commands(int commandValue)
    {
        var returnArray = _codeTable
            .Where(_codeTable => (_codeTable.code & commandValue) != 0)
            .Select(_codeTable => _codeTable.messege)
            .ToArray();
        return ((16 & commandValue) == 0) ? returnArray : returnArray.Reverse().ToArray();
    }
}
