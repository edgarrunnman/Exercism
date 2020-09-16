using System;

public static class Grains
{
    public static ulong Square(int n)
    {
        if (n <= 0 || n > 64) throw new ArgumentOutOfRangeException();
        ulong amountOfGrainsOnCell = 1;
        int i = 1;
        while (n > i++) amountOfGrainsOnCell *= 2;
        return amountOfGrainsOnCell;
    }
    public static ulong Total()
    {
        ulong amountOfGrainsOnCell = 1;
        ulong amountOfGrainsTotall = 1;
        int i = 1;
        while (64 > i++)
        {
            amountOfGrainsOnCell *= 2;
            amountOfGrainsTotall += amountOfGrainsOnCell;
        }
        return amountOfGrainsTotall;
    }
}