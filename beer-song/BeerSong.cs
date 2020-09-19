using System;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        string returnString = "";
        for (int i = 0; i < takeDown; i++)
        {
            if (startBottles == 0)
            {
                returnString += "No more bottles of beer on the wall, no more bottles of beer.\n";
                startBottles = 99;
                returnString += $"Go to the store and buy some more, {startBottles} bottles of beer on the wall.";

            }
            else if (startBottles == 1)
            {
                returnString += $"{startBottles} bottle of beer on the wall, {startBottles} bottle of beer.\n";
                startBottles -= 1;
                returnString += "Take it down and pass it around, no more bottles of beer on the wall.";
            }
            else
            {
                returnString += $"{startBottles} bottles of beer on the wall, {startBottles} bottles of beer.\n";
                startBottles -= 1;
                if (startBottles == 1) 
                    returnString += $"Take one down and pass it around, {startBottles} bottle of beer on the wall.";
                else 
                    returnString += $"Take one down and pass it around, {startBottles} bottles of beer on the wall.";
            }
            if ((takeDown > 1) && (i < (takeDown - 1))) 
                returnString += "\n\n";
        }
        return returnString;
    }
}