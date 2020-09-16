using System;
using System.Collections.Generic;

public static class Raindrops
{
    public static string Convert(int number)
    {
        List<int> factors = new List<int>();
        string output = "";
        for (int i = 1; i <= number; i++) 
        { 
            if ((number % i) == 0)
                switch (i)
                {
                    case 3:
                        output += "Pling";
                        break;
                    case 5:
                        output += "Plang";
                        break;
                    case 7:
                        output += "Plong";
                        break;
                    default:
                        break;
                }
        }
        if (output != "") return output;
        else return number.ToString();
    }
}