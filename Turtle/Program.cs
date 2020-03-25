using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Turtle
{
    public enum Direction
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3
    }

    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }


    }

    public class GameSettings
    {
        public Point Size { get; set; }
        public Point StartPoint { get; set; }
        public Point ExitPoint { get; set; }
        public Direction Direction { get; set; }
        public List<Point> Mines { get; set; }
    }

    public class Program
    {

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                throw new Exception("Error arguments dotnet run [File to path] [file to move]");
            }

            var settings = JsonConvert.DeserializeObject<GameSettings>(File.ReadAllText($@"{args[0]}"));

            var gameSettings = new GameSettings();
            gameSettings.Size = settings.Size;
            gameSettings.StartPoint = settings.StartPoint; // StartPoint
            gameSettings.ExitPoint = settings.ExitPoint;
            gameSettings.Direction = settings.Direction;
            gameSettings.Mines = settings.Mines;

            var file = File.ReadAllText($@"{args[1]}");

            List<string> listMoves = file.Split(';').ToList();
            var actions = new Actions();
            for (int i = 0; i < listMoves.Count; i++)
            {

                if (listMoves[i] == "r")
                {
                    gameSettings.Direction = actions.Rotate(gameSettings.Direction);//gameSettings.Direction.Rotate();
                    Console.WriteLine($"gameSettings.Direction:{gameSettings.Direction.ToString()}");
                    continue;
                }

                var newPoint = actions.Move(gameSettings.StartPoint, gameSettings.Direction);//gameSettings.StartPoint.Move(gameSettings.Direction);
                Console.WriteLine($"(X:{newPoint.X}, Y:{newPoint.Y})");
                if (!actions.isValidMove(newPoint, gameSettings.Size))
                {
                    Console.WriteLine($"Out of Bonds!!");
                    continue;
                }

                if (actions.ThereIsAMine(newPoint, gameSettings.Mines))
                {
                    Console.WriteLine($"Mine hit!!");
                    break;
                }

                if (actions.IsExitPoint(newPoint, gameSettings.ExitPoint))
                {
                    Console.WriteLine($"Success!!");
                    break;
                }

                if (i == listMoves.Count - 1)
                {
                    Console.WriteLine($"Still in Danger!!");

                }

            };
        }
    }
}
