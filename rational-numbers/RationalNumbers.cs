using System;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        double p;
        if (r.N > 0)
            p = Math.Pow(Convert.ToDouble(realNumber), Convert.ToDouble(r.N) / Convert.ToDouble(r.D));
        else
        {
            p = Math.Pow(Convert.ToDouble(realNumber), r.N);
            for (int i = 1; i < r.D; i++)
                p = Math.Sqrt(p);
        }
        return p;
    }
}

public struct RationalNumber
{
    public int N;
    public int D;
    public RationalNumber(int numerator, int denominator)
    {
        N = numerator;
        D = denominator;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        int r1F = 1;
        int r2F = 1;
        int faktorSearchSize = 1;
        while ((r1.D * r1F) != (r2.D * r2F))
        {
            for (int y = 1; y < faktorSearchSize; y++)
            {
                for(int n = 1; n < faktorSearchSize; n++)
                {
                    r1F = y;
                    r2F = n;
                    if ((r1.D * r1F) == (r2.D * r2F))
                        break;
                }
                if ((r1.D * r1F) == (r2.D * r2F))
                    break;
            }
            faktorSearchSize++;
        }
        int rtrnN = r1.N * r1F + r2.N * r2F;
        int rtrnD = r1.D * r1F;
        return Reduce(new RationalNumber(rtrnN, rtrnD));
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        int r1F = 1;
        int r2F = 1;
        int faktorSearchSize = 1;
        while ((r1.D * r1F) != (r2.D * r2F))
        {
            for (int y = 1; y <= faktorSearchSize; y++)
            {
                for (int n = 1; n <= faktorSearchSize; n++)
                {
                    r1F = y;
                    r2F = n;
                    if ((r1.D * r1F) == (r2.D * r2F))
                        break;
                }
                if ((r1.D * r1F) == (r2.D * r2F))
                    break;
            }
            faktorSearchSize++;
        }
        int rtrnN = r1.N * r1F - r2.N * r2F;
        int rtrnD = r1.D * r1F;
        return Reduce(new RationalNumber(rtrnN, rtrnD));
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        int rtrnN = r1.N * r2.N;
        int rtrnD = r1.D * r2.D;
        return Reduce(new RationalNumber(rtrnN, rtrnD));
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {

        int rtrnN = r1.N * r2.D;
        int rtrnD = r1.D * r2.N;
        return Reduce(new RationalNumber(rtrnN, rtrnD));
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(N), Math.Abs(D));
    }

    public RationalNumber Reduce()
    {
        return Reduce(new RationalNumber(N, D));
    }
    private static RationalNumber Reduce(RationalNumber n)
    {
        int divider = (n.N >= n.D) ? n.N : n.D;
        while (n.N % divider != 0 || n.D % divider != 0)
            divider--;
        if (n.N > 0 && n.D < 0)
        {
            n.N *= -1;
            n.D = Math.Abs(n.D);
        }
        else if (n.N < 0 && n.D < 0)
        {
            n.N = Math.Abs(n.N);
            n.D = Math.Abs(n.D);
        }
        return new RationalNumber(n.N / divider, n.D / divider);
    }

    public RationalNumber Exprational(int power)
    {
        int returnN = 1;
        int returnD = 1;
        for (int i = 0; i < power; i++)
        {
            returnN *= N;
            returnD *= D;
        }
        return new RationalNumber(returnN, returnD);
    }
}