using ToyRobot.Service;
using NUnit.Framework;

namespace ToyRobot.Tests
{
    [TestFixture]
    public class CommandProcessorTest
    {
        ICommandProcessor commandProcessor;

        [OneTimeSetUp]
        public void Setup()
        {
            IRobot robot = new Robot();
            commandProcessor = new CommandProcessor(robot);
        }

        [TestCase("PLACE 0,0,NORTH", "Output: 0,0,NORTH")]
        [TestCase("PLACE 5,5,SOUTH", "Output: 5,5,SOUTH")]
        [TestCase("PLACE", "Invalid Command.")]
        [TestCase("MOVE", "Output: 4,5,SOUTH")]
        [TestCase("RIGHT", "Output: 4,5,WEST")]
        [TestCase("LEFT", "Output: 4,5,SOUTH")]
        [TestCase("LEFT", "Output: 4,5,EAST")]
        [TestCase("MOVE", "Invalid Move.")]
        [TestCase("REPORT", "Output: 4,5,EAST")]
        [TestCase("PLACE -1,0,NORTH", "Invalid Position.")]
        [TestCase("PLACE 0,-1,NORTH", "Invalid Position.")]
        [TestCase("PLACE 6, 5,NORTH", "Invalid Position.")]
        [TestCase("place 5, 5,NORTH", "Output: 5,5,NORTH")]
        public void ProcessTest_ShouldReturnCorrectOutput_WhenCommandIsGiven(string command, string report)
        {           

            //Act
            var result = commandProcessor.Process(command);

            //Assert
            Assert.That(result, Is.EqualTo(report));
        }
    }
}