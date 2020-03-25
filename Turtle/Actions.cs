using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Turtle.Program;

namespace Turtle
{
    public class Actions : IActions
    {
        /// <summary>
        /// Checks if the point is the exit one
        /// </summary>
        /// <param name="newPoint"></param>
        /// <param name="exitPoint"></param>
        /// <returns></returns>
        public bool IsExitPoint(Point newPoint, Point exitPoint)
        {
            return newPoint.X == exitPoint.X && newPoint.Y == exitPoint.Y;
        }

        /// <summary>
        /// Checks if the move is in the bonds
        /// </summary>
        /// <param name="newPoint"></param>
        /// <param name="size"></param>
        /// <returns></returns>

        public bool isValidMove(Point newPoint, Point size)
        {
            return 0 <= newPoint.X && newPoint.X <= size.X && 0 <= newPoint.Y && newPoint.Y <= size.Y;
        }

        /// <summary>
        /// Moves the turtle forward
        /// </summary>
        /// <param name="currentPoint"></param>
        /// <param name="currentDirection"></param>
        /// <returns></returns>

        public Point Move(Point currentPoint, Direction currentDirection)
        {
            var newPoint = currentPoint;
            switch (currentDirection)
            {
                case Direction.North:
                    newPoint.Y += 1;
                    break;
                case Direction.East:
                    newPoint.X += 1;
                    break;
                case Direction.South:
                    newPoint.Y -= 1;
                    break;
                case Direction.West:
                    newPoint.X -= 1;
                    break;
                default:
                    break;
            }

            return newPoint;
        }

        /// <summary>
        /// Rotates the turtle 90 degrees
        /// </summary>
        /// <param name="currentDirection"></param>
        /// <returns></returns>
        public Direction Rotate(Direction currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.North:
                    return Direction.East;
                case Direction.East:
                    return Direction.South;
                case Direction.South:
                    return Direction.West;
                case Direction.West:
                    return Direction.North;
                default:
                    return Direction.North;
            }
        }

        /// <summary>
        /// Checks if there is a mine in the current point
        /// </summary>
        /// <param name="currentPoint"></param>
        /// <param name="mines"></param>
        /// <returns></returns>

        public bool ThereIsAMine(Point currentPoint, List<Point> mines)
        {
            return mines.Any(mine => mine.X == currentPoint.X && mine.Y == currentPoint.Y);
        }
    }
}
