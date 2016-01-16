using System;
using ToyRobot.Service;

namespace ToyRobot.Console
{
    class Program
    {
        private const string WELCOME_MESSAGE = "Welcome to the Toy Robot World!!";
        private const string COMMAND_INIT_MESSAGE = "Please enter the command!!";
        static void Main(string[] args)
        {
            System.Console.WriteLine(WELCOME_MESSAGE);
            System.Console.WriteLine(COMMAND_INIT_MESSAGE);

            IRobot robot = new Robot();
            ICommandProcessor commandProcessor = new CommandProcessor(robot);

            while (true)
            {
                System.Console.WriteLine(commandProcessor.Process(System.Console.ReadLine()));
            }
        }
    }
}
