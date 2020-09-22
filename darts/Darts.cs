using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        double distanceToCenter = Math.Sqrt(x * x + y * y);
        if (distanceToCenter >= 0 && distanceToCenter <= 1) return 10;
        if (distanceToCenter > 1 && distanceToCenter <= 5) return 5;
        if (distanceToCenter > 5 && distanceToCenter <= 10) return 1;
        return 0;

    }
}
