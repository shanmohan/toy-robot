using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;
using ToyRobot.Service;

namespace ToyRobot.Tests
{
    [TestClass]
    public class RobotTest
    {

        private IRobot robot;

        [TestInitialize]
        public void Setup()
        {
            robot = new Robot();
        }

        [TestMethod()]
        public void PlaceTest_ShouldReturnTrue_WhenValidArgumentsArepassed()
        {
            //Act
            var result = robot.Place(0,0,DirectionTypeEnum.NORTH);

            //Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void PlaceTest_ShouldReturnFalse_WhenValidArgumentsArepassed()
        {
            //Act
            var result = robot.Place(6, 0, DirectionTypeEnum.NORTH);

            //Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void MoveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RightTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void LeftTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ReportTest()
        {
            Assert.Fail();
        }
    }
}
