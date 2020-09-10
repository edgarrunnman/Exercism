using System;

public class Clock
{
    private string inputTimeString;

    private string hoursString;
    private string minutesString;
    private DateTime inputTimeDateTime;
    public Clock(int hours, int minutes)
    {
        inputTimeString = InputTimeToString(hours, minutes);
    }

    public Clock Add(int minutesToAdd)
    {
        DateTime time = inputTimeDateTime.Add(TimeSpan.FromMinutes(minutesToAdd));            
        return new Clock(time.Hour, time.Minute);
        return new Clock(10, 10);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        throw new NotImplementedException("You need to implement this function.");
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
        if (hours < 10) hoursString = $"0{hours}";
        else hoursString = Convert.ToString(hours);

        if (minutes < 10) minutesString = $"0{minutes}";
        else minutesString = Convert.ToString(minutes);
        inputTimeDateTime = DateTime.Parse($"{hoursString}:{minutesString}");
        return DateTime.Parse($"{hoursString}:{minutesString}").ToString("HH:mm");
    }
    private DateTime InputTimeToDateTIme(int hours, int minutes)
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
        if (hours < 10) hoursString = $"0{hours}";
        else hoursString = Convert.ToString(hours);

        if (minutes < 10) minutesString = $"0{minutes}";
        else minutesString = Convert.ToString(minutes);

        return DateTime.Parse($"{hoursString}:{minutesString}");
    }
}
