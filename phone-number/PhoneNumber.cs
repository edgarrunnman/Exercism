using System;
using System.Linq;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        string cleanPhoneNumber = "";
        foreach (char phoneNumberChar in phoneNumber)
            if (CharCheck(phoneNumberChar, '0', '9')) 
                cleanPhoneNumber += phoneNumberChar;

        if (
            cleanPhoneNumber[0] == '1'
            && CharCheck(cleanPhoneNumber[1], '2', '9')
            && CharCheck(cleanPhoneNumber[4], '2', '9')
            && cleanPhoneNumber.Length == 11
            )
        {
            cleanPhoneNumber = cleanPhoneNumber.TrimStart(cleanPhoneNumber[0]);
            return cleanPhoneNumber;
        }
        else if (
            CharCheck(cleanPhoneNumber[0], '2', '9')
            && CharCheck(cleanPhoneNumber[3], '2', '9')
            && cleanPhoneNumber.Length == 10
            ) 
            return cleanPhoneNumber;
        else 
            throw new ArgumentException();
    }
    private static bool CharCheck(char input, char start, char end)
    {
        bool returnBool = false;
        foreach (char allowedChar in Enumerable.Range((int)start, ((int)end + 1 - (int)start)))
            if (input == allowedChar) 
                returnBool = true;
        return returnBool;
    }
}