using System;

public class Clock
{
    private string inputTimeString;

    private string _hoursString;
    private string _minutesString;

    private int _hoursInteger;
    private int _minutesInteger;


    public Clock(int hours, int minutes)
    {
        inputTimeString = InputTimeToString(hours, minutes);
        _hoursInteger = hours;
        _minutesInteger = minutes;
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(_hoursInteger, _minutesInteger + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(_hoursInteger, _minutesInteger - minutesToSubtract);
    }
    public override string ToString()
    {
        return inputTimeString;
    }
    private string InputTimeToString(int hours, int minutes)
    {
        hours += (minutes / 60);
        hours = hours % 24;
        if (hours < 0) hours = 24 + hours;

        minutes = minutes % 60;
        if (minutes < 0)
        {
            minutes = 60 + minutes;
            hours--;
        }
        if (hours < 10) _hoursString = $"0{hours}";
        else _hoursString = Convert.ToString(hours);

        if (minutes < 10) _minutesString = $"0{minutes}";
        else _minutesString = Convert.ToString(minutes);
        return $"{_hoursString}:{_minutesString}";
    }
    
}
