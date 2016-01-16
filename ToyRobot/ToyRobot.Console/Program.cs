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
        private const string UNKNOWN_ERROR = "Unknown Error.";
        static void Main(string[] args)
        {
            try {
                System.Console.WriteLine(WELCOME_MESSAGE);
                System.Console.WriteLine(COMMAND_INIT_MESSAGE);

                IRobot robot = new Robot();
                ICommandProcessor commandProcessor = new CommandProcessor(robot);

                while (true)
                {
                    string output = commandProcessor.Process(System.Console.ReadLine());
                    if (output != "") {
                        System.Console.WriteLine(output);
                    }
                }
            }catch (Exception ex)
            {
                //TODO : Exception to be logged
                System.Console.WriteLine(UNKNOWN_ERROR);
            }
        }
    }
}
