﻿using System;

namespace ToyRobot.Service
{
    public class Robot : IRobot
    {
        #region Public Properties
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public DirectionTypeEnum CurrentDirection { get; set; }
        public string StatusMessage { get; set; }
        #endregion

        #region Private Properties
        private const int MaxX = 5;
        private const int MaxY = 5;
        private const string OPERATION_SUCCESSFULL = "Operation Successfull";
        private const string INVALID_POSITION = "Invalid Position.";
        private const string INVALID_MOVE = "Invalid Move.";
        #endregion

        #region Public Methods
        /// <summary>
        /// Method which handles the place command
        /// </summary>
        /// <param name="positionX">Coordinate X postion of the robot</param>
        /// <param name="positionY">Coordinate Y postion of the robot</param>
        /// <param name="defaultDirection">Default direction of the robot</param>
        /// <returns></returns>
        public bool Place(int positionX, int positionY, DirectionTypeEnum defaultDirection)
        {
            if (!IsPlacementValid(positionX, positionY, defaultDirection))
            {
                return false;
            }

            PositionX = positionX;
            PositionY = positionY;
            CurrentDirection = defaultDirection;
            StatusMessage = OPERATION_SUCCESSFULL;
            return true;

        }


        /// <summary>
        /// Method which handles the LEFT command
        /// </summary>
        /// <returns>Changes the direection to the left side and returns true</returns>
        public bool Left()
        {
            CurrentDirection = (Convert.ToInt16(CurrentDirection) > 1) ? CurrentDirection - 1 : CurrentDirection + 3;
            return true;
        }

        /// <summary>
        /// Method which handles the Move command
        /// </summary>
        /// <returns>If move allowed, moves the postion of the robot by single scale and returns True, Else returns false</returns>
        public bool Move()
        {
            if (IsMoveValid(CurrentDirection))
            {

                switch (CurrentDirection)
                {
                    case DirectionTypeEnum.NORTH:
                        PositionX++;
                        break;
                    case DirectionTypeEnum.EAST:
                        PositionY++;
                        break;
                    case DirectionTypeEnum.SOUTH:
                        PositionX--;
                        break;
                    case DirectionTypeEnum.WEST:
                        PositionY--;
                        break;
                }
                return true;
            }
            else
            {
                StatusMessage = INVALID_MOVE;
                return false;
            }
        }

        /// <summary>
        /// Reports the current postion of the robot
        /// </summary>
        /// <returns>Current Position</returns>
        public string Report()
        {
            return "Output: " + PositionX + "," + PositionY + "," + CurrentDirection.ToString();
        }

        /// <summary>
        /// Method which handles the RIGHT command
        /// </summary>
        /// <returns>Changes the direection to the right side and returns true</returns>
        public bool Right()
        {
            CurrentDirection = (Convert.ToInt16(CurrentDirection) < 4) ? CurrentDirection + 1 : CurrentDirection - 3;
            return true;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Checks whether placement anrgumens rae valid, Called before executing the PLACE command
        /// </summary>
        /// <param name="positionX">Initial X Coordinate of the robot</param>
        /// <param name="positionY">Initial Y Coordinate of the robot</param>
        /// <param name="defaultDirection">Default direction</param>
        /// <returns></returns>
        private bool IsPlacementValid(int positionX, int positionY, DirectionTypeEnum defaultDirection)
        {
            if (positionX < 0 || positionY < 0 || positionX > MaxX || positionY > MaxY)
            {
                StatusMessage = INVALID_POSITION;
                return false;
            }

            return true;
        }


        /// <summary>
        /// Checks whether move is valid based on the current coordinates, Called before executing the move command
        /// </summary>
        /// <param name="movingDirection">Direction to which robot has to be moved</param>
        /// <returns></returns>
        private bool IsMoveValid(DirectionTypeEnum movingDirection)
        {
            switch (movingDirection)
            {
                case DirectionTypeEnum.NORTH:
                    if (PositionX == 5) return false;
                    break;
                case DirectionTypeEnum.EAST:
                    if (PositionY == 5) return false;
                    break;
                case DirectionTypeEnum.SOUTH:
                    if (PositionX == 0) return false;
                    break;
                case DirectionTypeEnum.WEST:
                    if (PositionY == 0) return false;
                    break;
            }

            return true;
        }


        #endregion
    }
}
