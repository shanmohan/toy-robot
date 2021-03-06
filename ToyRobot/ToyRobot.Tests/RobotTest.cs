﻿using System;
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
        public void MoveTest_ShouldReturnTrueWhenPositionIsvalid(int postionX, int positionY, DirectionTypeEnum cuurrentDirection)
        {
            //Arrange
            robot.PositionX = postionX;
            robot.PositionY = positionY;
            robot.CurrentDirection = cuurrentDirection;

            //Act
            var result = robot.Move();

            //Assert
            Assert.That(result, Is.True);
        }

        [TestCase(0, 0, DirectionTypeEnum.SOUTH)]
        [TestCase(0, 0, DirectionTypeEnum.WEST)]
        [TestCase(5, 5, DirectionTypeEnum.NORTH)]
        [TestCase(5, 5, DirectionTypeEnum.EAST)]
        public void MoveTest_ShouldReturnFalseWhenPositionToInvalid(int postionX, int positionY, DirectionTypeEnum cuurrentDirection)
        {
            //Arrange
            robot.PositionX = postionX;
            robot.PositionY = positionY;
            robot.CurrentDirection = cuurrentDirection;

            //Act
            var result = robot.Move();

            //Assert
            Assert.That(result, Is.False);
        }

        [TestCase(DirectionTypeEnum.SOUTH, DirectionTypeEnum.WEST)]
        [TestCase(DirectionTypeEnum.EAST, DirectionTypeEnum.SOUTH)]
        [TestCase(DirectionTypeEnum.WEST, DirectionTypeEnum.NORTH)]
        [TestCase(DirectionTypeEnum.NORTH, DirectionTypeEnum.EAST)]
        public void RightTest_ShouldReturnChangedDirection_WhenCorrectComamndIsGiven(DirectionTypeEnum currentDirection, DirectionTypeEnum newDirection)
        {
            //Arrange
            robot.CurrentDirection = currentDirection;

            //Act
            var result = robot.Right();

            //Assert
            Assert.That(robot.CurrentDirection, Is.EqualTo(newDirection));
        }

        [TestCase(DirectionTypeEnum.SOUTH, DirectionTypeEnum.WEST)]
        [TestCase(DirectionTypeEnum.EAST, DirectionTypeEnum.SOUTH)]
        [TestCase(DirectionTypeEnum.WEST, DirectionTypeEnum.NORTH)]
        [TestCase(DirectionTypeEnum.NORTH, DirectionTypeEnum.EAST)]
        public void LeftTest_ShouldReturnChangedDirection_WhenCorrectComamndIsGiven(DirectionTypeEnum currentDirection, DirectionTypeEnum newDirection)
        {
            //Arrange
            robot.CurrentDirection = currentDirection;

            //Act
            var result = robot.Right();

            //Assert
            Assert.That(robot.CurrentDirection, Is.EqualTo(newDirection));
        }

        [TestCase(0, 0, DirectionTypeEnum.SOUTH, "Output: 0,0,SOUTH")]
        [TestCase(0, 5, DirectionTypeEnum.EAST, "Output: 0,5,EAST")]
        [TestCase(5, 0, DirectionTypeEnum.WEST, "Output: 5,0,WEST")]
        [TestCase(5, 5, DirectionTypeEnum.NORTH, "Output: 5,5,NORTH")]
        public void ReportTest_ShouldPrintOutput_WhenCorrectCommandIsGiven(int postionX, int positionY, DirectionTypeEnum directionType, string output)
        {
            //Arrange
            robot.PositionX = postionX;
            robot.PositionY = positionY;
            robot.CurrentDirection = directionType;

            //Act
            var result = robot.Report();

            //Assert
            Assert.That(result, Is.EqualTo(output));
        }
    }
}
