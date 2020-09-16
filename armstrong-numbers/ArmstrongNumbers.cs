using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        int testNumber = 0;
        string numberString = Convert.ToString(number);
        foreach (char partNumber in numberString)
        {
            double numberBase = double.Parse(partNumber.ToString());
            double numberPower = Convert.ToDouble(numberString.Length);
            testNumber += (int)Math.Pow(numberBase, numberPower);
        }
        if (testNumber == number || number == 0) return true;
        else return false;
    }
}