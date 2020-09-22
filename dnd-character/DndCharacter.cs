using System;
using System.Collections.Generic;
using System.Linq;

public class DndCharacter
{
    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
    public int Hitpoints { get; }

    public DndCharacter()
    {
        Strength = Ability();
        Dexterity = Ability();
        Constitution = Ability();
        Intelligence = Ability();
        Wisdom = Ability();
        Charisma = Ability();
        Hitpoints = 10 + Modifier(Constitution);
    }
    public static int Modifier(int score) => Convert.ToInt32(Math.Floor((score - 10.0) / 2.0));

    public static int Ability() 
    {
        Random random = new Random();
        List<int> throws = new List<int>();
        for (int i = 0; i < 4; i++)
            throws.Add(random.Next(1, 7));
        throws.Sort();
        throws.Reverse();
        throws.RemoveAt(3);
        return throws.Sum();
    }

    public static DndCharacter Generate() => new DndCharacter();

}
