using System;
using System.Linq;

public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}
public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        (int row, int column) positionWhite = (white.Row, white.Column);
        (int row, int column) positionBlack = (black.Row, black.Column);
        (int row, int column)[] moves = new (int, int)[8];
        for (int i = 0; i < 8; i++)
            moves[i] = positionWhite;
        for (int i = 0; i < 8; i++)
        {
            moves[0].row += 1;
            moves[1].row += 1;
            moves[1].column += 1;
            moves[2].column += 1;
            moves[3].row += 1;
            moves[3].column -= 1;
            moves[4].column -= 1;
            moves[5].row -= 1;
            moves[5].column -= 1;
            moves[6].row -= 1;
            moves[7].row -= 1;
            moves[7].column += 1;

            if (moves.Contains(positionBlack))
                return true;
        }
        return false;
    }
    public static Queen Create(int row, int column)
    {
        if (row > 7 || row < 0 || column > 7 || column < 0)
            throw new ArgumentOutOfRangeException();
        return new Queen(row, column);
    }
}