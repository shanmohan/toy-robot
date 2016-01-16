using System;
using ToyRobot.Service;

namespace ToyRobot.Console
{
    /// <summary>
    /// Toy Robot simulation client controller
    /// </summary>
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
                string output = commandProcessor.Process(System.Console.ReadLine());
                if (output != ""){
                    System.Console.WriteLine(output);
                }
            }
        }
    }
}
