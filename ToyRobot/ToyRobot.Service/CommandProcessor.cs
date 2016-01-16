using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    /// <summary>
    /// Class which manages the commands comming from the sonsole
    /// </summary>
    public class CommandProcessor : ICommandProcessor
    {

        #region Private Properties
        private const string INVALID_COMMAND = "Invalid Command.";

        private IRobot robot { get; set; }

        #endregion

        #region Public Methods
        /// <summary>
        /// Dependency is injected via constructor
        /// </summary>
        /// <param name="robot"></param>
        public CommandProcessor(IRobot robot)
        {
            this.robot = robot;
        }

        /// <summary>
        /// Method which manages the commands comming from the console
        /// </summary>
        /// <param name="commandString">Command string provided by the console/consumer</param>
        /// <returns></returns>
        public string Process(string commandString)
        {
            string command = "";
            bool commandResult = false;

            if (ValidateCommand(commandString))
            {
                command = GetCommand(commandString);
            }
            else
            {
                return robot.StatusMessage;
            }

            switch ((CommandTypeEnum)Enum.Parse(typeof(CommandTypeEnum), command, true))
            {
                case CommandTypeEnum.PLACE:
                    string arguments = commandString.Substring(commandString.IndexOf(" "));

                    string[] argArray = arguments.Split(',');

                    if (argArray.Length < 3) return INVALID_COMMAND;

                    int posX = Convert.ToInt16(argArray[0]);
                    int posY = Convert.ToInt16(argArray[1]);
                    string direction = argArray[2];

                    if (!Enum.IsDefined(typeof(DirectionTypeEnum), direction))
                    {
                        return INVALID_COMMAND;
                    }

                    commandResult = robot.Place(posX, posY, (DirectionTypeEnum)Enum.Parse(typeof(DirectionTypeEnum), direction, true));
                    return PrintOutput(commandResult);
                case CommandTypeEnum.MOVE:
                    commandResult = robot.Move();
                    return PrintOutput(commandResult);
                case CommandTypeEnum.LEFT:
                    commandResult = robot.Left();
                    return PrintOutput(commandResult);
                case CommandTypeEnum.RIGHT:
                    commandResult =  robot.Right();
                    return PrintOutput(commandResult);
                case CommandTypeEnum.REPORT:
                    return robot.Report();
                default:
                    return INVALID_COMMAND;

            }

        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Handles the output. It can be either success response or error status
        /// </summary>
        /// <param name="commandResult"></param>
        /// <returns></returns>
        private string PrintOutput(bool commandResult)
        {
            if (commandResult)
            {
                return robot.Report();
            }
            else
            {
                return robot.StatusMessage;
            }
        }
        /// <summary>
        /// Validates for the first command as this has to be always "PLACE"
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns></returns>
        private bool ValidFirstCommand(string commandString)
        {
            if (robot.CurrentDirection == 0 && (CommandTypeEnum)Enum.Parse(typeof(CommandTypeEnum), commandString, true) != CommandTypeEnum.PLACE)
            {
                robot.StatusMessage = INVALID_COMMAND;
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Returns the command from the console input string
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns>Command</returns>
        private string GetCommand(string commandString)
        {
            string command = "";
            if (Enum.IsDefined(typeof(CommandTypeEnum), commandString))
            {
                command = commandString;
            }
            else
            {
                command = commandString.Substring(0, commandString.IndexOf(" "));
            }

            return command;
        }
        /// <summary>
        /// Validates the commands for it's connrect anguments
        /// </summary>
        /// <param name="commandString"></param>
        /// <returns>True/False</returns>
        private bool ValidateCommand(string commandString)
        {


            if (Enum.IsDefined(typeof(CommandTypeEnum), commandString))
            {
                if ((CommandTypeEnum)Enum.Parse(typeof(CommandTypeEnum), commandString, true) != CommandTypeEnum.PLACE)
                {
                    if (ValidFirstCommand(commandString))
                    {
                        return true;
                    }
                    else
                    {
                        robot.StatusMessage = INVALID_COMMAND;
                        return false;
                    }
                }
                else
                {
                    robot.StatusMessage = INVALID_COMMAND;
                    return false;
                }
            }
            else
            {
                if (commandString.IndexOf(" ") == -1)
                {
                    robot.StatusMessage = INVALID_COMMAND;
                    return false;
                }
                else
                {
                    string str = commandString.Substring(0, commandString.IndexOf(" "));
                    if (ValidFirstCommand(str))
                    {
                        return true;
                    }
                    else
                    {
                        robot.StatusMessage = INVALID_COMMAND;
                        return false;
                    }

                }
            }
        }

        #endregion
    }
}
