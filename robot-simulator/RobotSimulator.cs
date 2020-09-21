using System;


public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    private Direction _direction;
    private int _x;
    private int _y;
    public RobotSimulator(Direction direction, int x, int y)
    {
        _direction = direction;
        _x = x;
        _y = y;
    }

    public Direction Direction { get => _direction; }

    public int X { get => _x; }

    public int Y { get => _y; }

    public void Move(string instructions)
    {
        int x = _x;
        int y = _y;
        foreach(var instruction in instructions)
        {
            if (instruction == 'R') 
                _direction = (Direction)(((int)_direction + 5) % 4);
            else if (instruction == 'L') 
                _direction = (Direction)(((int)_direction +3) % 4);
            else 
                switch (_direction)
                {
                    case Direction.North:
                        _y++;
                        break;
                    case Direction.East:
                        _x++;
                        break;
                    case Direction.South:
                        _y--;
                        break;
                    case Direction.West:
                        _x--;
                        break;
                }
        }
    }
}