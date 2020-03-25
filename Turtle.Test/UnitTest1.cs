using NUnit.Framework;
using System.Collections.Generic;
using Turtle;

namespace Tests
{
    public class Tests
    {
        private Actions actions;
        [SetUp]
        public void Setup()
        {
            actions = new Actions();
        }

        [Test]
        public void IsExitPoint_ReturnTrue()
        {
            var currentPoint = new Point(4,5);
            var exitPoint = new Point(4, 5);

            var result = actions.IsExitPoint(currentPoint, exitPoint);
                
            Assert.IsTrue(result);
        }

        [Test]
        public void IsExitPoint_ReturnFalse()
        {
            var currentPoint = new Point(4, 4);
            var exitPoint = new Point(4, 5);

            var result = actions.IsExitPoint(currentPoint, exitPoint);

            Assert.IsFalse(result);
        }

        [TestCase(4,6)]
        [TestCase(5,5)]
        [TestCase(-1, 5)]
        [TestCase(-1, -1)]
        [TestCase(4, -1)]
        public void IsValidMove_ReturnFalse(int x, int y)
        {
            var currentPoint = new Point(x, y);
            var size = new Point(4, 5);

            var result = actions.isValidMove(currentPoint, size);

            Assert.IsFalse(result);
        }

        [TestCase(4, 5)]
        [TestCase(2, 5)]
        [TestCase(1, 5)]
        [TestCase(4, 1)]
        [TestCase(2, 3)]
        public void IsValidMove_ReturnTrue(int x, int y)
        {
            var currentPoint = new Point(x, y);
            var size = new Point(4, 5);

            var result = actions.isValidMove(currentPoint, size);

            Assert.IsTrue(result);
        }

        [TestCase(4,5)]
        [TestCase(2,5)]
        [TestCase(1,2)]
        public void ThereIsAMine_ReturnTrue(int x, int y)
        {
            var currentPoint = new Point(x, y);
            var mines = new List<Point> { new Point(4,5), new Point(2,5), new Point(1,2) };

            var result = actions.ThereIsAMine(currentPoint, mines);

            Assert.IsTrue(result);
        }


        [TestCase(1, 5)]
        [TestCase(2, 1)]
        [TestCase(3, 3)]
        public void ThereIsAMine_ReturnFalse(int x, int y)
        {
            var currentPoint = new Point(x, y);
            var mines = new List<Point> { new Point(4, 5), new Point(2, 5), new Point(1, 2) };

            var result = actions.ThereIsAMine(currentPoint, mines);

            Assert.IsFalse(result);
        }

        [Test]
        public void Rotate_GivenNorth_ReturnEast()
        {
            Direction direction = Direction.North;

            var result = actions.Rotate(direction);

            Assert.AreEqual(result, Direction.East);
        }

        [Test]
        public void Rotate_GivenEast_ReturnSouth()
        {
            Direction direction = Direction.East;

            var result = actions.Rotate(direction);

            Assert.AreEqual(result, Direction.South);
        }

        [TestCase(0, 5)]
        [TestCase(1, 1)]
        [TestCase(2, 3)]
        public void Move_GivenEast_MoveXAxis(int x, int y)
        {
            Direction direction = Direction.East;

            var result = actions.Move(new Point(x,y), direction);

            Assert.AreEqual(result.X, x+1);
        }

        [TestCase(0, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 3)]
        public void Move_GivenNorth_MoveYAxis(int x, int y)
        {
            Direction direction = Direction.North;

            var result = actions.Move(new Point(x, y), direction);

            Assert.AreEqual(result.Y, y+1);
        }

    }
}