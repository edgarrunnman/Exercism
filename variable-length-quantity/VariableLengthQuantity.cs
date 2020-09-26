using System;
using System.Collections.Generic;
using System.Linq;

public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        var bitSeries = new List<char[]>();
        foreach (var number in numbers)
        {
            var bitString = Convert.ToString(number, 2).ToCharArray();
            int seriesCount = bitString.Length / 7;
            int firstSerieLenght = bitString.Length % 7;
            var serie = "10000000".ToCharArray();

            if (seriesCount == 0) 
                serie = "00000000".ToCharArray();

            for (int i = 1; i <= firstSerieLenght; i++)
                serie[8 - i] = bitString[bitString.Length - (seriesCount * 7 + i)];

            if (firstSerieLenght > 0) bitSeries.Add(serie);

            for (int i = 0; i < seriesCount; i++)
            {
                var part = "10000000".ToCharArray();

                if (seriesCount == i + 1) 
                    part[0] = '0';

                for (int y = 1; y <= 7; y++)
                    part[y] = bitString[bitString.Length - ((seriesCount - i) * 7 - y + 1)];

                bitSeries.Add(part);
            }
        }
        var returnSeries = new uint[bitSeries.Count];

        for (int i = 0; i < bitSeries.Count; i++)
            returnSeries[i] = (uint)Convert.ToInt32(new string(bitSeries[i]), 2);
        return 
            returnSeries;
    }

    public static uint[] Decode(uint[] bytes)
    {
        if (bytes.Length == 1 && (bytes[0] == 255 || bytes[0] == 128))
            throw new InvalidOperationException();

        string returnNumber = string.Empty;
        var returnNumbers = new List<uint>();
        foreach (var number in bytes)
        {
            var bitString = Convert.ToString(number, 2).PadLeft(8, '0');
            returnNumber += bitString.Substring(1);
            if (bitString.First() == '0')
            {
                returnNumbers.Add((uint)Convert.ToInt32(returnNumber, 2));
                returnNumber = string.Empty;
            }
        }
        return 
            returnNumbers.ToArray();
    }
}