using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private const string INVALID_POSITION = "Invalid postion.";
        private const string INVALID_MOVE = "Invalid Move.";
        #endregion

        #region Public Methods
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


        public bool Left()
        {
            CurrentDirection = (Convert.ToInt16(CurrentDirection) > 1) ? CurrentDirection - 1 : CurrentDirection + 3;
            return true;
        }

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

        public string Report()
        {
            return "Output: " + PositionX + "," + PositionY + "," + CurrentDirection.ToString();
        }

        public bool Right()
        {
            CurrentDirection = (Convert.ToInt16(CurrentDirection) < 4) ? CurrentDirection + 1 : CurrentDirection - 3;
            return true;
        }

        #endregion

        #region Private Methods

        private bool IsPlacementValid(int positionX, int positionY, DirectionTypeEnum defaultDirection)
        {
            if (positionX < 0 || positionY < 0 || positionX > MaxX || positionY > MaxY)
            {
                StatusMessage = INVALID_POSITION;
                return false;
            }

            return true;
        }


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
