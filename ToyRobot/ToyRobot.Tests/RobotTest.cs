using System;
using ToyRobot;
using ToyRobot.Service;
using NUnit.Framework;

namespace ToyRobot.Tests
{
    [TestFixture]
    public class RobotTest
    {

        private IRobot robot;

        [OneTimeSetUp]
        public void Setup()
        {
            robot = new Robot();
        }

        [TestCase(0, 4 ,DirectionTypeEnum.NORTH)]
        [TestCase(1, 0, DirectionTypeEnum.EAST)]
        [TestCase(2, 5, DirectionTypeEnum.SOUTH)]
        [TestCase(3, 0, DirectionTypeEnum.WEST)]
        public void PlaceTest_ShouldReturnTrue_WhenValidArgumentsArepassed(int postionX, int positionY, DirectionTypeEnum directionType)
        {
            //Act
            var result = robot.Place(postionX, positionY, directionType);

            //Assert
            Assert.That(result, Is.True);
        }

        [TestCase(-1, 4, DirectionTypeEnum.NORTH)]
        [TestCase(6, 0, DirectionTypeEnum.EAST)]
        [TestCase(2, 8, DirectionTypeEnum.SOUTH)]
        [TestCase(3, -1, DirectionTypeEnum.WEST)]
        public void PlaceTest_ShouldReturnFalse_WhenValidArgumentsArepassed(int postionX, int positionY, DirectionTypeEnum directionType)
        {
            //Act
            var result = robot.Place(postionX, positionY, directionType);

            //Assert
            Assert.That(result, Is.False);
        }

        [TestCase(0, 4, DirectionTypeEnum.NORTH)]
        [TestCase(1, 0, DirectionTypeEnum.EAST)]
        [TestCase(2, 5, DirectionTypeEnum.SOUTH)]
        [TestCase(5, 5, DirectionTypeEnum.WEST)]
        public void MoveTest_ShouldReturnTrueWhenInValidPositionToMove(int postionX, int positionY, DirectionTypeEnum directionType)
        {
            //Arrange
            robot.PositionX = postionX;
            robot.PositionY = positionY;
            robot.CurrentDirection = directionType;

            //Act
            var result = robot.Move();

            //Assert
            Assert.That(result, Is.True);
        }

        [TestCase(0, 0, DirectionTypeEnum.SOUTH)]
        [TestCase(0, 5, DirectionTypeEnum.EAST)]
        [TestCase(5, 0, DirectionTypeEnum.WEST)]
        [TestCase(5, 5, DirectionTypeEnum.NORTH)]
        public void MoveTest_ShouldReturnFalseWhenInValidPositionToMove(int postionX, int positionY, DirectionTypeEnum directionType)
        {
            //Arrange
            robot.PositionX = postionX;
            robot.PositionY = positionY;
            robot.CurrentDirection = directionType;

            //Act
            var result = robot.Move();

            //Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void RightTest()
        {
            Assert.Fail();
        }

        [Test]
        public void LeftTest()
        {
            Assert.Fail();
        }

        [Test]
        public void ReportTest()
        {
            Assert.Fail();
        }
    }
}
