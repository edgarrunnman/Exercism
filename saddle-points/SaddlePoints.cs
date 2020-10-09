using System;
using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        List<(int, int)> returnSaddlePoints = new List<(int, int)>();
        for (int x = 0; x < matrix.GetLength(0); x++)
        {
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                bool isSaddlePoint = true;
                for (int y2 = 0; y2 < matrix.GetLength(1); y2++)
                {
                    if (matrix[x, y] < matrix[x, y2])
                    {
                        isSaddlePoint = false;
                        break;
                    }
                }
                for (int x2 = 0; x2 < matrix.GetLength(0); x2++)
                {
                    if (!isSaddlePoint) break;
                    if (matrix[x, y] > matrix[x2, y])
                    {
                        isSaddlePoint = false;
                        break;
                    }
                }
                if (isSaddlePoint) returnSaddlePoints.Add((x+1, y+1));
            }
        }
        return returnSaddlePoints;
    }
}
