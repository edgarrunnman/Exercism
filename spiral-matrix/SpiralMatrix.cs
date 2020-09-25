using System;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int x = 0;
        int y = 0;
        int[,] matrix = new int[size, size];
        int counter = 0;
        for (int i = 1; i <= (size * 2 - 1); i++)
        {
            if (i / 2 % 2 == 0)
            {
                if (i % 2 == 0)
                {
                    for (int n = 0; n < size - i / 2; n++)
                    {
                        counter++;
                        matrix[y, x] = counter;
                        y--;
                    }
                    y++;
                    x++;
                }
                else
                {
                    for (int n = 0; n < size - i / 2; n++)
                    {
                        counter++;
                        matrix[y, x] = counter;
                        x++;
                    }
                    x--;
                    y++;
                }
            }
            else
            {
                if (i % 2 == 0)
                {
                    for (int n = 0; n < size - i / 2; n++)
                    {
                        counter++;
                        matrix[y, x] = counter;
                        y++;
                    }
                    y--;
                    x--;
                }
                else
                {
                    for (int n = 0; n < size - i / 2; n++)
                    {
                        counter++;
                        matrix[y, x] = counter;
                        x--;
                    }
                    x++;
                    y--;
                }
            }
        }
        return matrix;
    }
}
