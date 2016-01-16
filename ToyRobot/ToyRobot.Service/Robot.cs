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

        #region "Private Properties"
        private const int MaxX = 5;
        private const int MaxY = 5;
        private const string OPERATION_SUCCESSFULL = "Operation Successfull";
        private const string INVALID_POSITION = "Invalid postion.";
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

        public bool Left()
        {
            throw new NotImplementedException();
        }

        public bool Move()
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }

        public bool Right()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
