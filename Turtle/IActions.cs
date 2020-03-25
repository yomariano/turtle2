using System;
using System.Collections.Generic;
using System.Text;

namespace Turtle
{
    public interface IActions
    {
        Direction Rotate(Direction currentDirection);
        bool isValidMove(Point newPoint, Point size);
        bool ThereIsAMine(Point currentPoint, List<Point> mines);
        bool IsExitPoint(Point newPoint, Point exitPoint);
        Point Move(Point currentPoint, Direction currentDirection);
    }

}
