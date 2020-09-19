using System;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        bool hasZero = HasZero(side1, side2, side3);
        bool isEquilateral = IsEquilateral(side1, side2, side3);
        bool isIsosceles = IsIsosceles(side1, side2, side3);
        bool canFormTriangle = CanFormTriangle(side1, side2, side3);
        if (!isIsosceles && !isEquilateral && !hasZero && canFormTriangle) 
            return true;
        else 
            return false;
    }
    public static bool IsIsosceles(double side1, double side2, double side3)
    {
        bool pair1 = (side1 == side2);
        bool pair2 = (side1 == side3);
        bool pair3 = (side2 == side3);
        bool hasZero = HasZero(side1, side2, side3);
        bool canFormTriangle = CanFormTriangle(side1, side2, side3);
        if ((pair1 || pair2 || pair3) && !hasZero && canFormTriangle) 
            return true;
        else 
            return false;
    }
    public static bool IsEquilateral(double side1, double side2, double side3)
    {
        if (side1 == side2 && side2 == side3 && side1 != 0) 
            return true;
        else 
            return false;
    }
    private static bool HasZero(double side1, double side2, double side3)
    {
        return (side1 == 0)
            && (side2 == 0)
            && (side3 == 0);
    }
    private static bool CanFormTriangle(double side1, double side2, double side3)
    {
        return ((side1 + side2) > side3)
            && ((side2 + side3) > side1)
            && ((side3 + side1) > side2);
    }
}