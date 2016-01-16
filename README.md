# Toy Robot Simulator - Using C Sharp

## Instructions on how to run the code

1. `git clone https://github.com/shanmohan/toy-robot.git`
2. Open the ToyRobot.sln file
3. Set ToyRobot.Console project as "Set as StartUp Project"
4. Hit Start

## Stack 

1. VS 2015, C#, .Net 4.5, NUnit

## Remarks

1. High-level design sketch can be found under /Desings
2. Test data has been provided as part of respective test cases similar to below sample


        [TestCase("PLACE 0,0,NORTH", "")]
        [TestCase("PLACE 5,5,SOUTH", "")]
        [TestCase("PLACE", "Invalid Command.")]
        [TestCase("MOVE", "")]
        [TestCase("RIGHT", "")]
        [TestCase("LEFT", "")]
        [TestCase("LEFT", "")]
        [TestCase("MOVE", "Invalid Move.")]
        [TestCase("REPORT", "Output: 5,4,EAST")]
        [TestCase("PLACE -1,0,NORTH", "Invalid Position.")]
        [TestCase("PLACE 0,-1,NORTH", "Invalid Position.")]
        [TestCase("PLACE 6, 5,NORTH", "Invalid Position.")]
        [TestCase("place 5, 5,NORTH", "")]
        public void ProcessTest_ShouldReturnCorrectOutput_WhenCommandIsGiven(string command, string report)
		{}
